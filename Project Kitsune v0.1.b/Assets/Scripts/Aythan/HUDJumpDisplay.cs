using UnityEngine;
using System.Collections;

public class HUDJumpDisplay : MonoBehaviour
{
    public GameObject player;
    public GameObject[] jumpObjects = new GameObject[3];
<<<<<<< .merge_file_a05076

    // Use this for initialization
    void Start ()
    {
	
	}
=======
>>>>>>> .merge_file_a04460
	
	// Update is called once per frame
	void Update ()
    {
<<<<<<< .merge_file_a05076
        //if (Input.GetButton("Jump"))
        //{
            for (int i = 0; i < player.GetComponent<PlayerManager>().MaxNumberOfJumps; i++)
            {
            if (player.GetComponent<PlayerManager>().NumberOfJumps <= i)
=======
       for (int i = 0; i < jumpObjects.Length; i++)
       {
            if (player.GetComponent<PlayerManager>().NumberOfJumps < i + 1 || i + 1 >= player.GetComponent<PlayerManager>().MaxNumberOfJumps)
>>>>>>> .merge_file_a04460
            {
                jumpObjects[i].SetActive(false);
            }
            else jumpObjects[i].SetActive(true);
<<<<<<< .merge_file_a05076
            }
       // }
       // if (player.GetComponent<PlayerManager>().IsGrounded)
       // {
       //     for (int i = 0; i < player.GetComponent<PlayerManager>().MaxNumberOfJumps; i++)
       //     {
       //         jumpObjects[i].SetActive(true);
       //     }
       // }
=======
       }
>>>>>>> .merge_file_a04460
	}
}
