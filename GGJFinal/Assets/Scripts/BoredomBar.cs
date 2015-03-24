using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoredomBar : MonoBehaviour
{

		public float initial = 0.5f;
		public Slider slider;
		public bool spawnBoss;
		public bool attack;
		public GameObject boredAttack;
		public GameObject excitedAttack;
		GameObject wall;
		GameObject tempWall;
		Transform granny;
		Transform cam;
		float waitTime = 0.0f;
		bool bored = false;
		bool excited = false;
		public BoredomBar otherBar;


		// Use this for initialization
		void Awake ()
		{
				slider.value = initial;
				spawnBoss = false;
				attack = false;
				granny = GameObject.FindGameObjectWithTag ("Player").transform;
				wall = GameObject.FindGameObjectWithTag ("Wall");
				bored = false;
				excited = false;
				cam = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		}

		// Update is called once per frame
		void Update ()
		{

				if (bored) {
						if (Time.time - waitTime > 3) {
								bored = false;
								attack = false;
								slider.value = initial;
								waitTime = 0.0f;
								GameObject.DestroyObject (tempWall);
						}
						return;
				}

				if (excited) {
						if (Time.time - waitTime > 3.0f) {
								excited = false;
								attack = false;
								slider.value = initial;
								waitTime = 0.0f;
								GameObject.DestroyObject (tempWall);
						}
						return;
				}

				if (spawnBoss)
						return;
				if (slider.value > 0 && slider.value < slider.maxValue && !otherBar.attack) { // only decrement bar when other bar not full or empty
						slider.value -= 0.05f * Time.deltaTime;
				} else if (slider.value == slider.maxValue) {
						// set actions for full bar here
						excited = true;
						// attacks all enemies on the screen
						attack = true;
						tempWall = (GameObject)GameObject.Instantiate (wall, new Vector3 (cam.transform.position.x + 12.0f, 0.0f, 0.0f), Quaternion.identity);
						tempWall.GetComponent<FollowCam> ().enabled = false;

						GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
						foreach (GameObject enemy in enemies) {
								GameObject.Instantiate (excitedAttack, new Vector3 (enemy.transform.position.x, enemy.transform.position.y + 1.0f, 0.0f)
				                        , Quaternion.identity);

						}

						waitTime = Time.time;
				} else if (slider.value == slider.minValue) {
						// set actions for empty bar here
						bored = true;
						attack = true;
						tempWall = (GameObject)GameObject.Instantiate (wall, new Vector3 (cam.transform.position.x + 12.0f, 0.0f, 0.0f), Quaternion.identity);
						tempWall.GetComponent<FollowCam> ().enabled = false;

						GameObject.Instantiate (boredAttack, new Vector3 (granny.position.x, granny.position.y + 10.0f, 0.0f)
			                       				, granny.rotation);
						waitTime = Time.time;
				}
		}

		public void Entertained (int index)
		{
				if (index > 0) {
						// increment slider value whenever an enemy is killed
						slider.value += 0.2f * slider.maxValue;
				}
		else {
			// increment slider value whenever an enemy is killed
			slider.value += 0.1f * slider.maxValue;
		}
		}
}
