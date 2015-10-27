using UnityEngine;
using System.Collections;

public class ShrineManager : MonoBehaviour
{
    [HideInInspector]
    public bool CurrentlyActive = false;

    void OnCollisionEnter(Collision col)
    {
        //if (CurrentlyActive == false)
        //{
        //    if (col.gameObject.tag == "Player")
        //    {
        //        GetComponent<CameraScript>().Follow = gameObject;
        //    }


        //}
    }
}
