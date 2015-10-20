using UnityEngine;
using System.Collections;

public class PlayerGlide : MonoBehaviour
{

    public float GlidePower;
    Rigidbody ThisRigidBody;
    Vector3 GlideForce;

    void Start()
    {
         GlideForce = new Vector3(0.0f, GlidePower, 0.0f);
    }
	void LateUpdate ()
    {
        ThisRigidBody = GetComponent<Rigidbody>();

        ThisRigidBody.AddForce((GlideForce), ForceMode.Acceleration);

	}
}
