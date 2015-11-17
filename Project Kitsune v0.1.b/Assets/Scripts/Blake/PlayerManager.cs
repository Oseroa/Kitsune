using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public float MaxNumberOfJumps;
    [HideInInspector]
    public float JumpRechargeTime;
    [HideInInspector]
    public float NumberOfJumps;
    [HideInInspector]
    public bool IsGrounded = false;
    [HideInInspector]
    public float SpeedModifier = 0;
    [HideInInspector]
    public float g_Time = 0.0f;
    [HideInInspector]
    public Vector3 CurrentCheckPoint = new Vector3();

    public bool InfinateJumps;

    void Start()
    {
        if (InfinateJumps == true)
        {
            MaxNumberOfJumps = 100000;
        }
    }

}


