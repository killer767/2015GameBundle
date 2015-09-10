using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	
	public static int nowScoreBlue = 0;
	public static int nowScoreRed = 0;
	public static int nowScoreBlack = 0;
	
	void Start () {
		if(GameObject.Find("TheColor").tag == "Blue"){
			nowScoreBlue = 0;
		}
		if(GameObject.Find("TheColor").tag == "Red"){
			nowScoreRed = 0;
		}
		if(GameObject.Find("TheColor").tag == "Black"){
			nowScoreBlack = 0;
		}
	}
	
	void Update () {
		if(GameObject.Find("TheColor").tag == "Blue"){
			GetComponent<Text> ().text = "Score: " + nowScoreBlue.ToString ();
		}
		if(GameObject.Find("TheColor").tag == "Red"){
			GetComponent<Text> ().text = "Score: " + nowScoreRed.ToString ();
		}
		if(GameObject.Find("TheColor").tag == "Black"){
			GetComponent<Text> ().text = "Score: " + nowScoreBlack.ToString ();
		}
	}
	
	public static void AddScore_ (int amt) {
		if(GameObject.Find("TheColor").tag == "Blue"){
			nowScoreBlue += amt;
		}
		if(GameObject.Find("TheColor").tag == "Red"){
			nowScoreRed += amt;
		}
		if(GameObject.Find("TheColor").tag == "Black"){
			nowScoreBlack += amt;
		}
	}
}