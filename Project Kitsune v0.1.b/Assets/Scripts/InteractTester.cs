using UnityEngine;
using System.Collections;

public class InteractTester : MonoBehaviour
{
    public GameObject ParentGameObject;

    void OnTriggerStay(Collider col)
    {
        if(Input.GetButton("Interact"))
        {
            ParentGameObject.GetComponentInChildren<ShrineManager>().EventCompleted = true;
        }
    }


	
}
