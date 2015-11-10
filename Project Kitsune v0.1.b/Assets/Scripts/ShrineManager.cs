using UnityEngine;
using System.Collections;
public class ShrineManager : MonoBehaviour
{
    public GameObject LeftSideCollider;
    public GameObject RightSideCollider;
     
    [HideInInspector]
    public bool EventTriggered = false;

    [HideInInspector]
    public bool EventRunning = false;

    [HideInInspector]
    public bool EventCompleted = false;

    void OnTriggerStay(Collider col)
    {
     
            if (Input.GetButton("Interact") && col.tag == ("Player"))
            {

                GameObject CameraScapegoat = GameObject.FindGameObjectWithTag("MainCamera");

                CameraScapegoat.GetComponent<CameraScript>().enabled = false;
                CameraScapegoat.GetComponent<CameraEventScript>().followObject = gameObject;
                CameraScapegoat.GetComponent<CameraEventScript>().enabled = true;

                Collider LHS_ColScapegoat = LeftSideCollider.GetComponent<Collider>();

                LHS_ColScapegoat.enabled = true;

                Collider RHS_ColScapegoat = RightSideCollider.GetComponent<Collider>();

                RHS_ColScapegoat.enabled = true;

                EventTriggered = true;

                EventRunning = true;

                EventCompleted = false;

            }
        }
    

    void Update()
    {
        if (EventRunning == true)
        {
            if (EventCompleted == true)
            {
                GameObject CameraScapegoat = GameObject.FindGameObjectWithTag("MainCamera");

                CameraScapegoat.GetComponent<CameraEventScript>().enabled = false;

                CameraScapegoat.GetComponent<CameraScript>().enabled = true;

                Collider LHS_Scapegoat = LeftSideCollider.GetComponent<Collider>();
                Collider RHS_Scapegoat = RightSideCollider.GetComponent<Collider>();

                LHS_Scapegoat.enabled = false;
                RHS_Scapegoat.enabled = false;

            }
        }



    }
}
