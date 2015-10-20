using UnityEngine;
using System.Collections;

public class HUDUpdates : MonoBehaviour
{
    public GameObject followObject;
    public float rotateSpeed = 5.0f;
    public Canvas HUDCanvas;
    public Camera mainCamera;
    RectTransform CanvasRec;
    RectTransform thistransform;
    // Use this for initialization
    void Start ()
    {
        CanvasRec = HUDCanvas.GetComponent<RectTransform>();
        thistransform = transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update ()
    {
        //Rotate to mouse position on screen
        Vector3 vectorToTarget = Input.mousePosition - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);

        //follow the player around
        Vector2 ViewportPosition = mainCamera.WorldToViewportPoint(followObject.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(((ViewportPosition.x * CanvasRec.sizeDelta.x) - (CanvasRec.sizeDelta.x * 0.5f)), ((ViewportPosition.y * CanvasRec.sizeDelta.y) - (CanvasRec.sizeDelta.y * 0.5f)));
        thistransform.anchoredPosition = WorldObject_ScreenPosition;
	}
}
