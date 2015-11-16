using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class LanternScript : MonoBehaviour
{
    [HideInInspector]
    public bool Activated = false;


    void OnTriggerStay(Collider col)
    {
        if (Input.GetButton("Interact") || XCI.GetButton(XboxButton.A))
        {
            Activated = true;
        }
    }
}
