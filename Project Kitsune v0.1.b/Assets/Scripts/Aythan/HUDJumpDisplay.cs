using UnityEngine;
using System.Collections;

public class HUDJumpDisplay : MonoBehaviour
{
    public GameObject player;
    public GameObject[] jumpObjects = new GameObject[3];

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetButton("Jump"))
        //{
            for (int i = 0; i < player.GetComponent<PlayerManager>().MaxNumberOfJumps; i++)
            {
            if (player.GetComponent<PlayerManager>().NumberOfJumps <= i)
            {
                jumpObjects[i].SetActive(false);
            }
            else jumpObjects[i].SetActive(true);
            }
       // }
       // if (player.GetComponent<PlayerManager>().IsGrounded)
       // {
       //     for (int i = 0; i < player.GetComponent<PlayerManager>().MaxNumberOfJumps; i++)
       //     {
       //         jumpObjects[i].SetActive(true);
       //     }
       // }
	}
}
