using UnityEngine;
using System.Collections;

public class FallOffWindForce : MonoBehaviour
{
    private Vector3 UpwardWindForce = new Vector3(0.0f, 100.0f, 0.0f);

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("collision");
            Rigidbody p_rb = col.gameObject.GetComponent<Rigidbody>();

            p_rb.AddForce(UpwardWindForce, ForceMode.Impulse);
        }
    }
}
