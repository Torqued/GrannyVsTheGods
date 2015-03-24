using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GodEmotions : MonoBehaviour
{

		public Slider slider;
		public GameObject[] emotions; // from 1st to last, goes from min to max values
		GameObject curEmotion;
		float min;
		float second;
		float third;
		float fourth;
		float max;

	AudioSource[] aSources;
	AudioSource curSource;
		// Use this for initialization
		void Start ()
		{
				curEmotion = emotions [2];
				max = slider.maxValue;
				min = 0.0f;
				second = 0.33f * max;
				third = 0.66f * max;
				fourth = 0.99f * max;
		aSources = GetComponents<AudioSource> ();
		curSource = aSources [0];
		}
	
		// Update is called once per frame
		void Update ()
		{

		// starts off with 3rd emotion in array
				if (slider.value <= min) {
						if (!curEmotion.Equals (emotions [0])) {
								curEmotion.SetActive (false);
								curEmotion = emotions [0];
								curEmotion.SetActive (true);
				curSource.Stop();
				MakeSound(0);
						}
				} else if (slider.value < second) {
						if (!curEmotion.Equals (emotions [1])) {
								curEmotion.SetActive (false);
								curEmotion = emotions [1];
								curEmotion.SetActive (true);
						}
				} else if (slider.value < third) {
						if (!curEmotion.Equals (emotions [2])) {
								curEmotion.SetActive (false);
								curEmotion = emotions [2];
								curEmotion.SetActive (true);
						}
				} else if (slider.value < fourth) {
						if (!curEmotion.Equals (emotions [3])) {
								curEmotion.SetActive (false);
								curEmotion = emotions [3];
								curEmotion.SetActive (true);
						}
				} else if (slider.value <= max) {
						if (!curEmotion.Equals (emotions [4])) {
								curEmotion.SetActive (false);
								curEmotion = emotions [4];
								curEmotion.SetActive (true);
				curSource.Stop();
				MakeSound(0);
						}
				}
		}

	void MakeSound (int index)
	{

		// get a random audio clip for grandma 
		curSource = aSources [index];
		curSource.Play ();
	}
}
