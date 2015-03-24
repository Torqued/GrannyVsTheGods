using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector2.up * Time.deltaTime * 2);
		if(transform.position.y >= 25) Application.LoadLevel("EndingCutscene");
	}
}
