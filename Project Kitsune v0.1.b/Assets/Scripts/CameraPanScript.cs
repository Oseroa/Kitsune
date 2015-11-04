using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraPanScript : MonoBehaviour
{
    public float TimeSpentAtTarget;
    public float PanZAxisDistance;
    public float SmoothSpeed;
    public GameObject[] PanObjectList;

    float p_Time = 0.0f;
    [HideInInspector]
    public GameObject FollowTarget;
   

    private int ListSize = 0;
    private int CurrentElement = 0;

    private bool _runOnce = false;
    private bool AtTarget = false;
    private bool LastRun = false;

    private List<GameObject> SpiritList = new List<GameObject>();

    void LateUpdate()
    {

        if (_runOnce == false)
        {
            foreach (GameObject konoObject in PanObjectList)
            {
                SpiritList.Add(konoObject); //Sort later depending on specification
            }

           // GameObject PlayerScapegoat = GameObject.FindGameObjectWithTag("Player");

           // SpiritList.Add(PlayerScapegoat);
            _runOnce = true;
    

            FollowTarget = SpiritList[CurrentElement];
            ListSize = SpiritList.Count;

        }

        Vector3 UpdatedCameraPosition = FollowTarget.transform.position;

        UpdatedCameraPosition.z = FollowTarget.transform.position.z + -PanZAxisDistance;

        transform.position = Vector3.Lerp(transform.position, UpdatedCameraPosition, Time.deltaTime * SmoothSpeed);

        if (transform.position.x - FollowTarget.transform.position.x < 2)
        {
            AtTarget = true;
        }

        if (AtTarget == true)
        {
            p_Time += Time.deltaTime;

            if(LastRun == true && p_Time > TimeSpentAtTarget)
            {
                p_Time = 0.0f;
                GetComponent<CameraPanScript>().enabled = false;
                GetComponent<CameraScript>().enabled = true;
            }
            else if(CurrentElement != ListSize && p_Time > TimeSpentAtTarget)
            {
                p_Time = 0.0f;
                CurrentElement = CurrentElement + 1;
                FollowTarget = SpiritList[CurrentElement];
            }

            else if (CurrentElement == ListSize && p_Time > TimeSpentAtTarget)
            {
                p_Time = 0.0f;
                LastRun = true;
            }
            AtTarget = false;
        }



    }
}
