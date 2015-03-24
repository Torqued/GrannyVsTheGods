using UnityEngine;
using System.Collections;

public class FixFrameRate : MonoBehaviour {


	// Use this for initialization
	void Awake () {
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
