using UnityEngine;
using System.Collections;

public class HPGUI : MonoBehaviour {
	private GameObject cam;

	// Use this for initialization
	void Awake () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		transform.parent = cam.transform;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
