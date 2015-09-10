using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	bool isTouchBlue;
	bool isTouchRed;
	bool isTouchBlack;

	void Update () {
		if(isTouchBlue && Input.GetKey(KeyCode.E)){
			Application.LoadLevel("Blue");
		}
		if(isTouchRed && Input.GetKey(KeyCode.E)){
			Application.LoadLevel("Red");
		}
		if(isTouchBlack && Input.GetKey(KeyCode.E)){
			Application.LoadLevel("Black");
		}
	}

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Blue"){
			GameObject.Find("Choose").GetComponent<Text>().enabled = true;
			isTouchBlue = true;
		}
		if(other.tag == "Red"){
			GameObject.Find("Choose").GetComponent<Text>().enabled = true;
			isTouchRed = true;
		}
		if(other.tag == "Black"){
			GameObject.Find("Choose").GetComponent<Text>().enabled = true;
			isTouchBlack = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if(other.tag == "Blue"){
			GameObject.Find("Choose").GetComponent<Text>().enabled = false;
			isTouchBlue = false;
		}
		if(other.tag == "Red"){
			GameObject.Find("Choose").GetComponent<Text>().enabled = false;
			isTouchRed = false;
		}
		if(other.tag == "Black"){
			GameObject.Find("Choose").GetComponent<Text>().enabled = false;
			isTouchBlack = false;
		}
	}
}
