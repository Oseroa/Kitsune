using UnityEngine;
using System.Collections;

public class WindZoneUp : MonoBehaviour
{

    Vector3 UpwardForce = new Vector3(0.0f, 65.0f, 0.0f);

	void OnCollisionEnter(Collision col)
    {
        col.rigidbody.AddForce(UpwardForce, ForceMode.Acceleration);
    }
}
