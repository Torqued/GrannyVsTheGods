using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	GameObject granny; 
	Transform curPos;
	// Use this for initialization
	void Start () {
		granny = GameObject.FindGameObjectWithTag ("Player");
		curPos = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		curPos = granny.transform;
		if (curPos.position.x > this.transform.position.x)
			this.transform.position = new Vector3 (curPos.position.x, 0.0f, -10.0f);
	}
}
