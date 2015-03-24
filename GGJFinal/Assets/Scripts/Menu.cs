using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public string nextScene = "GameMap";

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return)) {
			Application.LoadLevel (nextScene); 

		}
		
	}

	public void RestartLevel() {
		Application.LoadLevel ("GameMap"); 
	}

	public void ReturnToTitle() {
		Application.LoadLevel ("TitleScreen"); 
	}
}
