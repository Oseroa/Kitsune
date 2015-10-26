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

    void OnTriggerStay(Collider other)
    {
        Vector3 addForce = windForce;
        addForce.z = 0;
        Rigidbody otherRigid = other.GetComponent<Rigidbody>();
        if (otherRigid.mass >= 1) addForce *= 30;
        Vector3 finalForce = new Vector3(Mathf.Lerp(0, addForce.x, 1), Mathf.Lerp(0, addForce.y, 1),0);
        otherRigid.AddForce(finalForce);
    }
}
