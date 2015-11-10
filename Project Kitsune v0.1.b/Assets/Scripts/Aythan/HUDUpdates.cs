using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class HUDUpdates : MonoBehaviour
{
    public GameObject followObject;
    public float rotateSpeed = 5.0f;
    public Canvas HUDCanvas;
    public Camera mainCamera;
    RectTransform CanvasRec;
    RectTransform thistransform;
    float currentAngle;
    // Use this for initialization
    void Start ()
    {
        CanvasRec = HUDCanvas.GetComponent<RectTransform>();
        thistransform = transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update ()
    {
        //Rotate circle thingy to mouse position on screen or controller if one is plugged in
       
        float angle = 0.0f;
        if (XCI.IsPluggedIn(1))
        {
            float x = XCI.GetAxisRaw(XboxAxis.RightStickX);
            float y = XCI.GetAxisRaw(XboxAxis.RightStickY);
            if (x != 0.0f || y != 0.0f)
            {
                angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
                currentAngle = angle;
            }
            else angle = currentAngle;
        }
        else
        {
            Vector3 vectorToTarget = Input.mousePosition - transform.position;
            angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        }
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);

        //follow the player around
        Vector2 ViewportPosition = mainCamera.WorldToViewportPoint(followObject.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(((ViewportPosition.x * CanvasRec.sizeDelta.x) - (CanvasRec.sizeDelta.x * 0.5f)), ((ViewportPosition.y * CanvasRec.sizeDelta.y) - (CanvasRec.sizeDelta.y * 0.5f)));
        thistransform.anchoredPosition = WorldObject_ScreenPosition;
	}
}
