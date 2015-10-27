using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{
    public GameObject TargetNodeA;
    public GameObject TargetNodeB;

    public float PlatformMovementSpeed;

    GameObject CurrentTarget;

    void Update()
    {
        float EachStep = PlatformMovementSpeed * Time.deltaTime;

        if (CurrentTarget == null)
        {
            CurrentTarget = TargetNodeA;
        }

        transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.transform.position, EachStep);
        
        if(CurrentTarget.transform.position == transform.position)
        {
            if(CurrentTarget == TargetNodeA)
            {
                CurrentTarget = TargetNodeB;
            }

            else if (CurrentTarget == TargetNodeB)
            {
                CurrentTarget = TargetNodeA;
            }
        }


    }
}
