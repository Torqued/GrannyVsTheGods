using UnityEngine;
using System.Collections;

public class MinionGenerator : MonoBehaviour {

	public GameObject minionA; 
	public GameObject minionB; 
	Transform cam;
	public int total = 0; 
	public int max = 10;
	// Use this for initialization
	void Awake () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		// if total is less than max, spawn a new minion slightly outside of the screen and have him move towards the left
		if (total < max) {
			float y = -1.0f * Random.Range(0,4);
			GameObject temp = (GameObject) GameObject.Instantiate(minionA, cam.position + new Vector3(12.0f, y, 10.0f) , cam.rotation);
			temp.transform.parent = transform;
			total++;
		}
	}
}
