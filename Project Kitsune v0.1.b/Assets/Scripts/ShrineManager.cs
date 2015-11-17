using UnityEngine;
using System.Collections;

public class ShrineManager : MonoBehaviour
{
    public GameObject LeftSideCollider;
    public GameObject RightSideCollider;
    public GameObject[] PanToObjects;

    public GameObject FirstLantern;
    public GameObject SecondLantern;
    public GameObject ThirdLantern;

    [HideInInspector]
    public bool PanHasFinished = false;

    [HideInInspector]
    public bool EventTriggered = false;

    [HideInInspector]
    public bool EventRunning = false;

    [HideInInspector]
    public bool EventCompleted = false;

    void OnTriggerStay(Collider col)
    {
        GameObject CameraScapegoat = GameObject.FindGameObjectWithTag("MainCamera");

        if (!PanHasFinished)
        {
            CameraPanScript cps = CameraScapegoat.GetComponent<CameraPanScript>();
            cps.PanObjectList = PanToObjects;
            cps.ActivatingShrine = gameObject;
            cps.enabled = true;
            CameraScapegoat.GetComponent<CameraScript>().enabled = false;
        }
        else
        {
            if (EventTriggered == false)
            {
                if (col.tag == ("Player"))
                {
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
        }
    }

    void Update()
    {
        bool lant1 = FirstLantern.GetComponent<LanternScript>().Activated;
        bool lant2 = SecondLantern.GetComponent<LanternScript>().Activated;
        bool lant3 = SecondLantern.GetComponent<LanternScript>().Activated;

        if (lant1 && lant2 && lant3)
        {
            EventCompleted = true;
        }
        if (EventRunning == true)
        {
            
            if (EventCompleted == true)
            {
                GameObject CameraScapegoat = GameObject.FindGameObjectWithTag("MainCamera");

                CameraScapegoat.GetComponent<CameraEventScript>().enabled = false;

                CameraScapegoat.GetComponent<CameraScript>().enabled = true;

                Collider LHS_Scapegoat = LeftSideCollider.GetComponent<Collider>();
                Collider RHS_Scapegoat = RightSideCollider.GetComponent<Collider>();

                GameObject placeHolder = GameObject.FindGameObjectWithTag("Player");

                placeHolder.GetComponent<PlayerManager>().MaxNumberOfJumps += 1;
                LHS_Scapegoat.enabled = false;
                RHS_Scapegoat.enabled = false;

            }
        }

    }
}
