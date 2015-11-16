using UnityEngine;
using System.Collections;

public class LanternScript : MonoBehaviour
{
    [HideInInspector]
    public bool Activated = false;


    void OnTriggerStay(Collider col)
    {
        if (Input.GetButton("Interact"))
        {
            Activated = true;
        }
    }
}
