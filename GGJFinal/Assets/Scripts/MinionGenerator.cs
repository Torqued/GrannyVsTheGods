using UnityEngine;
using System.Collections;

public class MinionGenerator : MonoBehaviour
{

		public GameObject minionA;
		public GameObject minionB;
		Transform cam;
		public int total = 0;
		public int max = 10;
		// Use this for initialization
		void Awake ()
		{
				cam = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
				
				if (total < 0) 
						total = 0;
				// if total is less than max, spawn a new minion slightly outside of the screen and have him move towards the left
				if (total < max) {
						float y = Random.Range (2.5f, 4.0f);
						int type = Random.Range (0, 2);
						float x = Random.Range (0.0f, 8.0f); 
						GameObject temp;
						if (type > 0)
								temp = (GameObject)GameObject.Instantiate (minionA, cam.position + new Vector3 (12.0f + x, y * -1.0f, 10.0f), cam.rotation);
						else {
								temp = (GameObject)GameObject.Instantiate (minionB, cam.position + new Vector3 (12.0f + x, y * -1.0f, 10.0f), cam.rotation);
						}
						temp.transform.parent = transform;
						total++;
				}
		}
}
