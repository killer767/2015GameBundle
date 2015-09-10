using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallSpawner : MonoBehaviour {

	[SerializeField] GameObject ball;
	public float speed;
	public float leftBorder, rightBorder;
    public Animator anim;
	
	public static bool isStart;
	float x;
	bool holdFire = false;
	
	void Start () {
		x = -0.5f;
		isStart = false;
		GameExit.isExit = false;
		GameObject.Find("GameStart").GetComponent<Text>().enabled = true;
		GameObject.Find("Comment").GetComponent<Text>().enabled = true;
		
	}
	
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.S) || isStart){
			GameObject.Find("GameStart").GetComponent<Text>().enabled = false;
			GameObject.Find("Comment").GetComponent<Text>().enabled = false;

			if(GameObject.Find("TheColor").tag == "Red"){
				anim.SetTrigger("Move");
			}

			isStart = true;
			
			if(Input.GetKey(KeyCode.A)){
				x -= speed;
			}
			if(Input.GetKey(KeyCode.D)){
				x += speed;
			}
			x = Mathf.Clamp(x, leftBorder, rightBorder);
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
			
			if(!holdFire && Input.GetKeyDown(KeyCode.Space)){
				StartCoroutine("Spanwer");
			}
			if(Timer.timesup == true){
				holdFire = true;
				GameObject.Find("TimesUp").GetComponent<Text>().enabled = true;
			}
		}
	}
	
	IEnumerator Spanwer(){
		GameObject bullet = (GameObject)Instantiate (
			ball,
			transform.position,
			Quaternion.identity
			);
		bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0, 300f, 300f));
		holdFire = true;
		GameObject.Find("Basketball").GetComponent<MeshRenderer>().enabled = false;
		
		yield return new WaitForSeconds (.5f);
		holdFire = false;
		GameObject.Find("Basketball").GetComponent<MeshRenderer>().enabled = true;
		
	}
}
