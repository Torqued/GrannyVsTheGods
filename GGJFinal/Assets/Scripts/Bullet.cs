using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		rigidbody2D.AddForce(Vector2.right * -500);
	}


	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			GrannyController granny = other.gameObject.GetComponent<GrannyController>();
			granny.Hurt();
			other.gameObject.rigidbody2D.AddForce(Vector2.right * -1000);
		}
		
	}
}
