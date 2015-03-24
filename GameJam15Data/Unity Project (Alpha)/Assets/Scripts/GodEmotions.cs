using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GodEmotions : MonoBehaviour {

	public Slider slider; 
	public GameObject[] emotions; // from 1st to last, goes from min to max values
	GameObject curEmotion;
	float first;
	float second; 
	float third;
	float fourth;
	float max;
	// Use this for initialization
	void Start () {
		curEmotion = emotions [2];
		max = slider.maxValue;
		first = 0.2f * max;
		second = 0.4f * max;
		third = 0.6f * max;
		fourth = 0.8f * max;
	}
	
	// Update is called once per frame
	void Update () {
		// starts off with 3rd emotion in array
		if (slider.value < first) {
			if (!curEmotion.Equals(emotions[0])) {
				curEmotion.SetActive(false);
				curEmotion = emotions[0];
				curEmotion.SetActive(true);
			}
		}
		else if (slider.value < second) {
			if (!curEmotion.Equals(emotions[1])) {
				curEmotion.SetActive(false);
				curEmotion = emotions[1];
				curEmotion.SetActive(true);
			}
		}
		else if (slider.value < third) {
			if (!curEmotion.Equals(emotions[2])) {
				curEmotion.SetActive(false);
				curEmotion = emotions[2];
				curEmotion.SetActive(true);
			}
		}
		else if (slider.value < fourth) {
			if (!curEmotion.Equals(emotions[3])) {
				curEmotion.SetActive(false);
				curEmotion = emotions[3];
				curEmotion.SetActive(true);
			}
		}
		else if (slider.value < max) {
			if (!curEmotion.Equals(emotions[4])) {
				curEmotion.SetActive(false);
				curEmotion = emotions[4];
				curEmotion.SetActive(true);
			}
		}
	}
}
