using UnityEngine;
using System.Collections;

public class GameExit : MonoBehaviour {

	public static bool isExit;

	void Start () {

	}
	
	void Update () {
		if(Input.GetKey(KeyCode.Q)){
			isExit = true;
		}
	}
}
