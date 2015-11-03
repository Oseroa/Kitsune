using UnityEngine;
using System.Collections;


public class PlatformGlue : MonoBehaviour
{

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            col.gameObject.transform.position = Vector3.Lerp(col.gameObject.transform.position, transform.position, Time.deltaTime );
        }
    }



}
