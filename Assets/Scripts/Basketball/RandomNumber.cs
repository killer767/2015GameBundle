using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomNumber : MonoBehaviour {

	int number;
	bool isChange = true;

	void Start () {
		Randomnumber();
	}
	
	void Update () {
		if(isChange == false){
			Randomnumber();
		}
	}

	void Randomnumber(){
		number = Random.Range(-20, 20);
		GetComponent<TextMesh> ().text = number.ToString ();
		isChange = true;
		StartCoroutine("Wait_");
	}

	IEnumerator Wait_(){
		yield return new WaitForSeconds (3f);
		isChange = false;
	}

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Ball"){
			Score.AddScore_(number);
			other.GetComponent<AudioSource>().Play();
		}
	}
}
