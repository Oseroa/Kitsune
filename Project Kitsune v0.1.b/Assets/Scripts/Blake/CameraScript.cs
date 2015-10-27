﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject Follow;
    public float CameraSmooth;

    [HideInInspector]
    public Vector3 CameraPosition = new Vector3();

    void Update()

    {
        CameraPosition.x = Follow.transform.position.x;
        CameraPosition.y = Follow.transform.position.y + 2;
        CameraPosition.z = Follow.transform.position.z - 15;

        transform.position = Vector3.Lerp(transform.position, CameraPosition, (CameraSmooth * Time.deltaTime));
    }
}
