using UnityEngine;
using System.Collections;

public class HUDJumpDisplay : MonoBehaviour
{
    public GameObject player;
    public GameObject[] jumpObjects;

    void Start()
    {
        if (player.GetComponent<PlayerManager>().InfinateJumps)
        {
            for (int i = 0; i < 6; i++)
            {
                jumpObjects[i].SetActive(false);
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (!player.GetComponent<PlayerManager>().InfinateJumps)
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
}
