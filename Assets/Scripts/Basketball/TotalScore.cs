using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TotalScore : MonoBehaviour {

	int totalScore = 0;

	void Start () {
		totalScore = Score.nowScoreBlue + Score.nowScoreRed + Score.nowScoreBlack;
		Debug.Log(totalScore);
		GetComponent<Text> ().text = "Total Score: " + totalScore.ToString ();
		#if UNITY_WEBGL || UNITY_WEBPLAYER
		GJBase.instance.AddScore(totalScore);
		#endif
	}
	
	void Update () {

	}
}
