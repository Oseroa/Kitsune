using UnityEngine;
using System.Collections;

public class COL_ToHome : MonoBehaviour {

	
    void OnCollisionEnter(Collision col)
    {
        col.transform.position = new Vector3(0,1,0);
    }
}
