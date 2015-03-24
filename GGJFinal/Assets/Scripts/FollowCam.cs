using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public Transform cam; 
	float offset = 0.0f;
	float initial_y = 0.0f;
	float initial_z = 0.0f;
	// Use this for initialization
	void Start () {
		offset = cam.position.x - transform.position.x;
		initial_y = transform.position.y;
		initial_z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		if (cam.position.x - transform.position.x > offset) {
			transform.position = new Vector3(cam.position.x - offset, initial_y, initial_z);
			
		}
	}
}
