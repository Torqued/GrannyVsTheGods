using UnityEngine;
using System.Collections;

public class SpecialAttacks : MonoBehaviour
{

		GrannyController granny;
		float startTime = 0.0f;
		bool hit = false;
		// Use this for initialization
		void Awake ()
		{
				granny = GameObject.FindGameObjectWithTag ("Player").GetComponent<GrannyController> ();
				startTime = Time.time;
				if (this.gameObject.tag == "BoredAttack1") { 
						this.gameObject.rigidbody2D.isKinematic = true;
				}
				hit = false;
		}

		// Update is called once per frame
		void Update ()
		{ // destroy all attacks after 3.0 seconds

				if (this.gameObject.tag == "BoredAttack1" && (Time.time - startTime) < 1.0f) { 
						Vector2 temp = Vector2.zero;
						Vector2 result = Vector2.SmoothDamp (transform.position, granny.transform.position, ref temp, Time.deltaTime * 4);
						this.transform.position = new Vector3 (result.x, this.transform.position.y, this.transform.position.z);
				} else if (Time.time - startTime >= 1.0f && this.gameObject.tag == "BoredAttack1") {
						if (!hit) 
								this.gameObject.rigidbody2D.isKinematic = false;
				}
				if (Time.time - startTime > 3.0f)
						DestroyObject (this.gameObject);
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (this.gameObject.tag == "BoredAttack1" && other.collider2D.tag == "GroundTrigger") {
						hit = true;
						this.rigidbody2D.isKinematic = true;
						this.rigidbody2D.velocity = Vector2.up * 10.0f;
						GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");
						CamShake shaker = cam.GetComponent<CamShake> ();
						shaker.Shake ();
						shaker.shake_decay = 0.05f;
				}
		
		

		}
}
