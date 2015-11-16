using UnityEngine;
using System.Collections;

public class HUDJumpDisplay : MonoBehaviour
{
    public GameObject player;
    public GameObject[] jumpObjects = new GameObject[3];
	
	// Update is called once per frame
	void Update ()
    {
       for (int i = 0; i < jumpObjects.Length; i++)
       {
            if (player.GetComponent<PlayerManager>().NumberOfJumps < i + 1 || i + 1 > player.GetComponent<PlayerManager>().MaxNumberOfJumps)
            {
                jumpObjects[i].SetActive(false);
            }
            else jumpObjects[i].SetActive(true);
       }
	}
}
