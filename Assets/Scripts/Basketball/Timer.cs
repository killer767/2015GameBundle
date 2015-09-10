using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	
	public static bool timesup;
	public float startTime = 50f;
	
	void Start () {
		timesup = false;
	}
	
	void Update () {
		if(BallSpawner.isStart == true){
			if (startTime > 0) {
				if(GameExit.isExit == true) {
					timesup = true;
					startTime = 0;
					StartCoroutine("Count");
				}
				startTime -= Time.deltaTime;
			}
			else if(timesup == false) {
				timesup = true;
				startTime = 0;
				StartCoroutine("Count");
			}
		}
		GetComponent<Text> ().text = "Time: " + startTime.ToString ("f0");
	}
	
	IEnumerator Count () {
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("Besketball");
	}
}
