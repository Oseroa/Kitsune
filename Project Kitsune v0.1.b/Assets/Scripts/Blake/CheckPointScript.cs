using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour

{

    void OnTriggerStay(Collider col)
    {
        if (Input.GetButton("Interact"))
            {
                col.gameObject.GetComponent<PlayerManager>().CurrentCheckPoint = transform.position;
                print("Checkpoint");
            }

    }

	
}
