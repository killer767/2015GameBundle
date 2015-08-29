using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class LifeCounter : MonoBehaviour {

	public Text lifeText;
	public static int life;
	public bool isGameOver;

	[SerializeField] private FirstPersonController fpsCtrler;

	void Start(){

	}

	void Update(){
		if(isGameOver == true){
			fpsCtrler.WalkSpeed = 0f;
			fpsCtrler.RunSpeed = 0f;
			GameObject.Find("Menu").SendMessage("Stop");
			GameObject.Find("Player").transform.position = new Vector3(0f, 1.5f, -8f);
		}
	}

	public void AddLife (int amt) {
		life = life + amt;
		if (life > 0) {
			if(life > 3){
				life = 3;
			}
			lifeText.text = life.ToString("0");
		}
		else {
			lifeText.text = "0";
			GameObject.Find("Die").GetComponent<Text>().enabled = true;
			GameObject.Find("Die").GetComponent<Animator>().SetBool("DieShow",true);
			isGameOver = true;
		}
	}

	public void IsGameOver (int amt){
		if(amt == 20){
			isGameOver = true;
		}
		if(amt == 15){
			isGameOver = false;
		}
	}
}