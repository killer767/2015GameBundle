using UnityEngine;
using System.Collections;

public class Basketball : MonoBehaviour {


	void Start (){

	}

	void OnTriggerEnter (Collider other) {
		if(GameObject.Find("TheColor").tag == "Blue" || GameObject.Find("TheColor").tag == "Red"){
			if (other.tag == "NetBlue") {
				GetComponent<AudioSource>().Play();
				Score.AddScore_(5);
			}
			if (other.tag == "NetRed") {
				GetComponent<AudioSource>().Play();
				Score.AddScore_(5);
			}
		}
		if(other.tag == "Des"){
			Destroy(gameObject, 2f);
		}
	}
}
