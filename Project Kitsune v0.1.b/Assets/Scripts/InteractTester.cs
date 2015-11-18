using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class InteractTester : MonoBehaviour
{
    public GameObject ParentGameObject;

    void OnTriggerStay(Collider col)
    {
        if(Input.GetButton("Interact") || XCI.GetButton(XboxButton.A))
        {
            ParentGameObject.GetComponentInChildren<ShrineManager>().EventCompleted = true;
        }
    }


	
}
