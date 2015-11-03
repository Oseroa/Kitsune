using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject Follow;
    public float CameraSmooth;
    public float CameraDistance;

    [HideInInspector]
    public Vector3 CameraPosition = new Vector3();

    void FixedUpdate()

    {
        CameraPosition.x = Follow.transform.position.x;
        CameraPosition.y = Follow.transform.position.y + 2;
        CameraPosition.z = Follow.transform.position.z + -CameraDistance;

        transform.position = Vector3.Lerp(transform.position, CameraPosition, (CameraSmooth * Time.deltaTime));
    }
}
