using UnityEngine;
using System.Collections;

public class OnAirTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerManager>().NumberOfJumps = col.gameObject.GetComponent<PlayerManager>().MaxNumberOfJumps;

        }

    }


}
