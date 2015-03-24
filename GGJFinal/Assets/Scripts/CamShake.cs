using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {
	//SCRIPT TO SHAKE CAMERA
	//FOUND ON UNITY ANSWERS

	private Vector3 originPosition;
	private Quaternion originRotation;
	
	public float shake_decay;
	private float shake_intensity;
	
	// Update is called once per frame
	void Update () {

		if (shake_intensity > 0) {
			Vector3 temp = Random.insideUnitSphere;
						transform.position = originPosition + temp * shake_intensity;
						transform.rotation = new Quaternion (
				originRotation.x + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity, shake_intensity) * .2f);
						shake_intensity -= shake_decay;
				} else {
			transform.rotation = Quaternion.identity; 
			transform.position = new Vector3(transform.position.x, 0.0f, -10.0f);
				}
	
	}

	public void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
		shake_intensity = .3f;
		shake_decay = 0.02f;
	}

}
