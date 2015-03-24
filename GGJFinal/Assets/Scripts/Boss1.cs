using UnityEngine;
using System.Collections;

public class Boss1 : MonoBehaviour
{

		private GameObject cam;
		private CamShake shaker;
		GameObject globalData;					// GameObject containing player data and HashIDs
		HashIDs hash;							// The HashIDs
		Animator animator; 						// Controls animation

		bool onGround = false;
		public int hp = 30;
		public GameObject bullet;
		public Transform bulletSpawner;
		AudioClip thump;
		AudioClip clunk;
		AudioClip shoot;

		// Use this for initialization
		void Awake ()
		{
				cam = GameObject.FindGameObjectWithTag ("MainCamera");
				shaker = cam.GetComponent<CamShake> ();
				globalData = GameObject.FindGameObjectWithTag ("GameController");
				animator = GetComponent<Animator> ();
				hash = globalData.GetComponent<HashIDs> ();
				bullet = Resources.Load ("bullet") as GameObject;

				//AUDIO
				thump = Resources.Load ("Sound/BossThump") as AudioClip;
				clunk = Resources.Load ("Sound/Clunk") as AudioClip;
				shoot = Resources.Load ("Sound/Shoot") as AudioClip;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (onGround)
						animator.SetTrigger (hash.punchTrigger);
	
		}

		void Fire ()
		{
				Instantiate (bullet, bulletSpawner.position, Quaternion.identity);
				MakeSound (shoot);
		}

		void Die ()
		{
				SpawnHitEffect (Resources.Load ("Effects/HitEffectBoss") as GameObject);

				Instantiate (Resources.Load ("Effects/Rubble Bits") as GameObject, transform.position, Quaternion.identity);
				shaker.Shake ();
				shaker.shake_decay = 0.007f;
				//Destroy (this.gameObject);
		
				//DO WHATEVER GAME OVER THINGS HERE
				Invoke ("Win", 2);
		}
		
		void Win ()
		{
				ScreenFade fader = globalData.GetComponent<ScreenFade> ();
				fader.EndScene2 ();
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
						onGround = true;
						shaker.Shake ();
						MakeSound (thump);
				}
		
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				bool invincible = (animator.GetCurrentAnimatorStateInfo (0).nameHash == hash.hurtState ||
						animator.GetCurrentAnimatorStateInfo (0).nameHash == hash.fireState ||
						animator.GetCurrentAnimatorStateInfo (0).nameHash == hash.punchingState);
				if (other.gameObject.tag == "Melee" && !invincible) {
						animator.SetTrigger (hash.hurtTrigger);
						hp -= 1; //HURT ENEMY
						if (hp <= 0)
								Die ();
				} else if (other.gameObject.tag == "Melee" && invincible && !audio.isPlaying)
						MakeSound (clunk);
		
		}

		void MakeSound (AudioClip clip)
		{
				audio.clip = clip;
				audio.Play ();
		}

		void SpawnHitEffect (GameObject effect)
		{
				Instantiate (effect, bulletSpawner.position, Quaternion.identity);
		}

}
