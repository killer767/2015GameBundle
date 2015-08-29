using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RollMessage : MonoBehaviour {

	RawImage pic;
	int num = -410;
	int upBorder = -410, downBorder = 430;

	public Animator m_animator;

	void Start () {
		pic = GetComponent<RawImage>();
	}
	
	void Update () {
		num = Mathf.Clamp(num, upBorder, downBorder);

		if(Input.GetKey(KeyCode.UpArrow)){
			num = num +3;
			pic.rectTransform.anchoredPosition3D = new Vector3(0, num, 0);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			num = num -3;
			pic.rectTransform.anchoredPosition3D = new Vector3(0, num, 0);
		}

		if(Input.GetKey(KeyCode.Q)){
			m_animator.SetBool("Show", false);
		}
	}

	public void ShowMessage(){
		m_animator.SetBool("Show", true);
	}
}
