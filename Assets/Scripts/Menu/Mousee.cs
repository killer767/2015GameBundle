using UnityEngine;
using System.Collections;

public class Mousee : MonoBehaviour {

	private Animator m_animator;

	void Start () {
		m_animator = GetComponentInParent<Animator> ();
	}
	
	void Update () {
	
	}

	public void OnMouseEnter(){
		m_animator.SetBool ("IN", true);
		Debug.Log ("in");
	}

	public void OnMouseExit(){
		m_animator.SetBool ("IN", false);
		Debug.Log ("out");
	}
}
