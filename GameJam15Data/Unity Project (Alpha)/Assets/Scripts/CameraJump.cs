using UnityEngine;
using System.Collections;

public class CameraJump : MonoBehaviour {
	public GameObject granny;
	private float ground = -3.715f;
	private Vector3 initialPosition;

	void Start() {
		initialPosition = this.transform.position;
	}
	
	void Update () {
		float offsetY = granny.transform.position.y - ground;

		this.transform.position = new Vector3 (initialPosition.x, initialPosition.y - offsetY, initialPosition.z);
	}
}
