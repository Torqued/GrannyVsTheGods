using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public Transform cam; 
	float offset = 0.0f;
	// Use this for initialization
	void Start () {
		offset = cam.position.x - transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (cam.position.x - transform.position.x > offset) {
			transform.position = new Vector3(cam.position.x - offset, transform.position.y, 0.0f);
			
		}
	}
}
