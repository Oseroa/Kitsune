using UnityEngine;
using System.Collections;

public class CameraEventScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject followObject;
    [HideInInspector]
    public GameObject playerObject;

    [HideInInspector]
    public Vector3 gCameraPosition = new Vector3();

	void Update ()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        gCameraPosition.x = playerObject.transform.position.x;

        gCameraPosition.y = playerObject.transform.position.y + 2;

        gCameraPosition.z = followObject.transform.position.z - 20;


        transform.position = Vector3.Lerp(transform.position, gCameraPosition, Time.deltaTime);


	}
}
