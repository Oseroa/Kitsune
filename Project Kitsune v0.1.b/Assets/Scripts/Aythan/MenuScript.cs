using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void PlayButtonPress()
    {
        Application.LoadLevel("tester");
    }

    public void QuitButtonPress()
    {
        Application.Quit();
    }
}
