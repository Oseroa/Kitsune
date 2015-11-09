using UnityEngine;
using System.Collections;

public class Soundbutton : MonoBehaviour {

	public AudioSource quackSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Mouse0)){
			quackSound.Play();
		}
	}
}
