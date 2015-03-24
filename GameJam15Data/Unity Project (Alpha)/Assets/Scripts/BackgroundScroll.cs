using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
	public GameObject mainCamera;
	public float speed = 0;
	
	// Update is called once per frame
	void Update () {
		float cameraPos = mainCamera.transform.position.x;
		renderer.material.mainTextureOffset = new Vector2 (cameraPos * speed, 0);
	}
}
