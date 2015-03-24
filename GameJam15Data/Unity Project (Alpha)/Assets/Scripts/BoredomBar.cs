using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoredomBar : MonoBehaviour {

	public float initial = 0.5f; 
	public Slider slider; 
	// Use this for initialization
	void Start () {
		slider.value = initial;
	}
	
	// Update is called once per frame
	void Update () {
		if (slider.value > 0 && slider.value < slider.maxValue) {
						slider.value -= 0.05f * Time.deltaTime;
				} else if (slider.value == slider.maxValue) {
					// set actions for full bar here 
				}

		// increment slider value whenever an enemy is killed
	}
}
