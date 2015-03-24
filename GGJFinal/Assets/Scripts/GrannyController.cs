using UnityEngine;
using System.Collections;

public class GrannyController : MonoBehaviour
{

		public Camera cam;
		Transform granny;
		public bool facingRight = true;			// For determining which way the player is currently facing.
		public bool jump = false;				// Condition for whether the player should jump.
		public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	
		public float moveForce = 365f;			// Amount of force added to move the player left and right.
		public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	
		private Transform groundCheck;			// A position marking where to check if the player is grounded.
		private bool grounded = false;			// Whether or not the player is grounded.
		public bool moving = false; 			// Whether or not we're moving.
		public bool attacking = false;			// Whether or not we're attacking.

		private Animator anim;					// Reference to the player's animator component.

		GameObject globalData;					// GameObject containing player data and HashIDs
		HashIDs hash;							// The HashIDs
		Animator animator; 						// Controls animation

		public int hp = 5;						//number of hearts 

		public Transform[] hearts;				//hearts;

		BoredomBar barA;
		BoredomBar barB;
		MinionGenerator generator;
		GameObject wall;
		public bool bossTime;
		public bool bossSpawned = false;
		public GameObject boss;
		AudioSource[] aSources;
		AudioSource curSource;
		// Use this for initialization
		void Awake ()
		{
				groundCheck = transform.Find ("groundCheck");
				granny = this.transform;
				globalData = GameObject.FindGameObjectWithTag ("GameController");
				animator = GetComponent<Animator> ();
				hash = globalData.GetComponent<HashIDs> ();
				barA = GameObject.FindGameObjectWithTag ("BoredomBarA").GetComponent<BoredomBar> ();
				barB = GameObject.FindGameObjectWithTag ("BoredomBarB").GetComponent<BoredomBar> ();
				generator = GameObject.FindGameObjectWithTag ("EnemyGenerator").GetComponent<MinionGenerator> ();
				wall = GameObject.FindGameObjectWithTag ("Wall");
				bossTime = false;
				bossSpawned = false;
				aSources = GetComponents<AudioSource> ();
				curSource = aSources [0];
		}

		void spawnBoss ()
		{


				// now set up a wall to the right so we can't move to the right either.
				GameObject temp = (GameObject)GameObject.Instantiate (wall, new Vector3 (cam.transform.position.x + 12.0f, 0.0f, 0.0f), Quaternion.identity);
				temp.GetComponent<FollowCam> ().enabled = false;
				// we now have a static game scene with no enemies so ready to spawn boss 
				GameObject.Instantiate (boss, new Vector3 (cam.transform.position.x + 8.0f, 0.0f, 0.0f), Quaternion.identity);
		}
		// Update is called once per frame
		void Update ()
		{

				// make the distance check first 
				if (transform.position.x > 100) {
						Debug.Log ("boss time");
						// first, don't spawn any more enemies, and don't decrease the boredom bar anymore;
						if (!bossTime) {
								barA.spawnBoss = true;
								barB.spawnBoss = true;
								generator.max = 0;
								bossTime = true;
						}
						
						
						// now check if there are any more enemies.when no more enemies, we set up wall and spawn boss
						if (GameObject.FindGameObjectWithTag ("Enemy") == null && !bossSpawned) {
								spawnBoss ();
								bossSpawned = true;
						}
				}
				// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
				grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground")); 

				//player is attacking if they're in any of the punch combo states.
				attacking = (animator.GetCurrentAnimatorStateInfo (0).nameHash == hash.punchingState) ||
						(animator.GetCurrentAnimatorStateInfo (0).nameHash == hash.punching2State) ||
						(animator.GetCurrentAnimatorStateInfo (0).nameHash == hash.shoeState);

				animator.SetBool (hash.onGroundBool, grounded);
				animator.SetBool (hash.movingBool, moving);
				// If the jump button is pressed and the player is grounded then the player should jump.
				if (Input.GetButtonDown ("Jump") && grounded && !attacking) {
						animator.SetTrigger (hash.jumpTrigger);
						jump = true;
				}

				//Detect if player is punching! 
				//Change Input settings! It's the "X" button
				if (Input.GetButtonDown ("Punch") && grounded) {
						//if(!attacking) Punch();
						int temp = Random.Range (0, 3);
						if (temp == 1) {
								curSource.Stop ();
								MakeSound2 (-1);
						}
						Punch ();
				}

				// Cache the horizontal input.
				float h = Input.GetAxis ("Horizontal");

				//player is moving if they're pressing an arrow key while either in moving or idle state
				if (h != 0 && (animator.GetCurrentAnimatorStateInfo (0).nameHash == hash.movingState || 
						(animator.GetCurrentAnimatorStateInfo (0).nameHash == hash.idleState)))
						moving = true;
				else
						moving = false;
	
				// h is -1 if moving left, and 1 if moving right. 0 if not moving

				// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
				if (h * rigidbody2D.velocity.x < maxSpeed)
			// add a force to the player.
				if (moving)
						rigidbody2D.AddForce (Vector2.right * h * moveForce);
		
				// If the player's horizontal velocity is greater than the maxSpeed...
				if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
			// ... clamp the player's velocity to the maxSpeed in the x axis.
						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
				// If the input is moving the player right and the player is facing left...
				if (h > 0 && !facingRight)
			// ... flip the player.
						Flip ();

		// Otherwise if the input is moving the player left and the player is facing right...
		else if (h < 0 && facingRight)
			// ... flip the player.
						Flip ();

		}

		void Flip ()
		{
				// Switch the way the player is labelled as facing.
				facingRight = !facingRight;

				// make the player face different direction
				transform.Rotate (0.0f, 180.0f, 0.0f);
		}

		void Punch ()
		{
			
				animator.SetTrigger (hash.punchTrigger);


		}

		void SpawnHitEffect (GameObject effect)
		{
				Instantiate (effect, transform.position, Quaternion.identity);
		}
	
		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "EnemyMelee") {
						Hurt ();

				}
		
				if (other.gameObject.tag == "BossMelee") {
						Hurt ();
						rigidbody2D.AddForce (Vector2.right * -2000);
				}


				if (other.gameObject.tag == "BoredAttack1") {
						Hurt ();
				}
		
		}

		public void Hurt ()
		{	
		if (hp <= 0) 
						return;
				animator.SetTrigger (hash.hurtTrigger);
				int temp = Random.Range (0, 3);
				if (temp == 1) {
						curSource.Stop ();
						MakeSound2 (-1);
				}

				hp -= 1;
				if (hp >= 0)
						GameObject.DestroyObject (hearts [hp].gameObject); //DESTRY THE HEARTS AS HP GOES DOWN
				if (hp <= 0)
						Die ();
		}

		void Die ()
		{
				animator.SetBool (hash.deadBool, true);
				animator.SetTrigger (hash.deadTrigger);
				curSource.Stop ();
				MakeSound2 (12);
				//DO WHATEVER GAME OVER THINGS HERE
				Invoke ("Lost", 3);
				barA.spawnBoss = true;
				barB.spawnBoss = true;
				generator.max = 0;
		}
		
		void Lost ()
		{
				ScreenFade fader = globalData.GetComponent<ScreenFade> ();
				fader.EndScene1 ();
		
		}

		void Win ()
		{

		}

		void FixedUpdate ()
		{
				if (jump) {
			
						// Add a vertical force to the player.
						rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
						// Make sure the player can't jump again until the jump conditions from Update are satisfied.
						jump = false;
				}
		}

	void MakeSound (AudioClip clip) {
		audio.clip = clip;
		audio.Play ();
		}
		void MakeSound2 (int index)
		{
				if (index < 0)
						index = Random.Range (0, 8);
				// get a random audio clip for grandma 
				curSource = aSources [index];
				curSource.Play ();
		}

	
}
