using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

	private bool isGetKey;
	private bool isFound;

	[SerializeField] private FirstPersonController fpsCtrler;

	void Start () {
		isGetKey = false;
		isFound = false;
	}
	
	void Update () {

		if (Input.GetKeyDown (KeyCode.P) && isGetKey == true) {
			GameObject.Find("Bed").GetComponent<Animator>().enabled = true;
			GameObject.Find("PressP").GetComponent<Text>().enabled = false;
			GameObject.Find("Haha").GetComponent<Text>().enabled = true;
			GameObject.Find("Bed").GetComponent<AudioSource>().Play();
			StartCoroutine("WaitBed");
		}

		if (Input.GetKeyDown (KeyCode.P) && isFound == true) {
			GameObject.Find("End").GetComponent<Text>().enabled = true;
			StartCoroutine("WaitEnd");
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "Curtain") {
			GameObject.Find("RoomDoor").GetComponentInChildren<Animator>().SetTrigger("Open");
			StartCoroutine("WaitDoor");
		}

		if (other.name == "Bed") {
			GameObject.Find("PressP").GetComponent<Text>().enabled = true;
			isGetKey = true;
		}

		if (other.name == "END_SHIT") {
			isFound = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.name == "Bed") {
			GameObject.Find ("PressP").GetComponent<Text> ().enabled = false;
			isGetKey = false;
		}

		if (other.name == "END_SHIT") {
			isFound = false;
		}
	}

	IEnumerator WaitBed(){
		fpsCtrler.WalkSpeed = 0f;
		fpsCtrler.RunSpeed = 0f;
		yield return new WaitForSeconds (3);
		GameObject.Find("Haha").GetComponent<Text>().enabled = false;
		GameObject.Find("LifeCounter").SendMessage("AddLife", -5);

	}

	IEnumerator WaitDoor(){
		yield return new WaitForSeconds (4);
		GameObject.Find ("DoorHold").GetComponent<Animator> ().enabled = true;
	}

	IEnumerator WaitEnd(){
		fpsCtrler.WalkSpeed = 0f;
		fpsCtrler.RunSpeed = 0f;
		yield return new WaitForSeconds (2);
		GameObject.Find("End").GetComponent<Text>().enabled = false;
		GameObject.Find("LifeCounter").SendMessage("IsGameOver", 20);
		yield return new WaitForSeconds (1);
		GameObject.Find ("Menu").GetComponent<Animator> ().SetBool ("Hide",false);
		GameObject.Find ("Menu").GetComponentInChildren<Button>().enabled = true;
	}
}