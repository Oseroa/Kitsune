using UnityEngine;
using System.Collections;

public class WindCollider : MonoBehaviour
{
    public Vector3 windForce;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Vector3 addForce = windForce;
        addForce.z = 0;
        Rigidbody otherRigid = other.GetComponent<Rigidbody>();
        if (otherRigid.mass >= 1) addForce *= 350;
        otherRigid.AddForce(addForce);
    }
}
