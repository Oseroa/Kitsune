using UnityEngine;
using System.Collections;

public class VirtualGravity : MonoBehaviour
{

	public float FallSpeed;

	void LateUpdate ()
    {
        Vector3 FallSpeedVector = new Vector3(0, -FallSpeed, 0);
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(FallSpeedVector,ForceMode.Acceleration);

	}
}
