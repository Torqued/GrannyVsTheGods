using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour {

	public GameObject bgSprite; 
	// Use this for initialization
	public int totalSprites = 20;
	public float offset = 8.0f; 
	void Start () {
		// take the position of the original bg sprite and add another 20
		GameObject tempSprite; 
		for (int i = 0; i< totalSprites; i++) {
			tempSprite = (GameObject) GameObject.Instantiate(bgSprite);
			tempSprite.transform.parent = this.transform;
			tempSprite.transform.position = new Vector3(bgSprite.transform.position.x + offset + i*offset, bgSprite.transform.position.y, 
			                                            bgSprite.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
