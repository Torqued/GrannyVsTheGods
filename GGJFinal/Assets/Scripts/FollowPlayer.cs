using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

		GameObject granny;
		Transform curPos;
		BoredomBar barA;
		BoredomBar barB;
		bool standby = false;
		Vector3 currentpos;
		// Use this for initialization
		void Start ()
		{
				granny = GameObject.FindGameObjectWithTag ("Player");
				barA = GameObject.FindGameObjectWithTag ("BoredomBarA").GetComponent<BoredomBar> ();
				barB = GameObject.FindGameObjectWithTag ("BoredomBarB").GetComponent<BoredomBar> ();
				curPos = this.transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
				curPos = granny.transform;
				
				if (curPos.position.x > this.transform.position.x && !granny.GetComponent<GrannyController> ().bossSpawned && !barA.attack && !barB.attack) {
						Vector2 temp = Vector2.zero;
						Vector2 result = Vector2.SmoothDamp (transform.position, curPos.position, ref temp, Time.deltaTime * 4);
						this.transform.position = new Vector3 (result.x, 0.0f, this.transform.position.z);
				}
		}

}
