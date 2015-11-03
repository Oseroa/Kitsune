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

        gCameraPosition.x = followObject.transform.position.x;

        //Follow "Player" Y
        gCameraPosition.y = playerObject.transform.position.y + 2;

        gCameraPosition.z = followObject.transform.position.z - 15;


        transform.position = Vector3.Lerp(transform.position, gCameraPosition, Time.deltaTime);


	}
}
