using UnityEngine;
using System.Collections;

public class AlphaPulse : MonoBehaviour {

	public float speed = 0;

	void Update () {
		Color color = renderer.material.color;
		color.a = (Mathf.Sin(Time.time*speed) + 1)/2;
		renderer.material.color = color;
	}
}
