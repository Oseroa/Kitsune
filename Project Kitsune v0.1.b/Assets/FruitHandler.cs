using UnityEngine;
using System.Collections;

public class FruitHandler : MonoBehaviour
{
    public float GrowTime = new float();
    Vector3 HomePosition = new Vector3();
    Vector3 StartScale = new Vector3();
    Vector3 IncrementAmount = new Vector3(0.001f, 0.001f, 0.001f);

    float g_Time = 0.0f;
    bool FullyGrown = false;
    bool IsActive = true;

    Rigidbody MyBody;

    void Start()
    {
        Rigidbody ThisBody = GetComponent<Rigidbody>();

        ThisBody.mass = Random.Range(0.008f, 0.001f);
        ThisBody.drag = Random.Range(0.04f, 0.06f);

        HomePosition = transform.position;
        StartScale = transform.localScale;
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        GrowTime += Random.Range(0.1f, 2.1f);
    }

    void OnColliderEnter(Collision col)
    {
        IsActive = false;
    }

    void Update()
    {
        g_Time += Time.deltaTime;
        MyBody = GetComponent<Rigidbody>();

        if(IsActive == false)
        {
            transform.position = HomePosition;
            GetComponent<VirtualGravity>().enabled = false;
            MyBody.constraints = RigidbodyConstraints.FreezeAll;
        }


        if (g_Time < GrowTime && FullyGrown == false)
        {
            IsActive = true;
            GetComponent<VirtualGravity>().enabled = false;
            MyBody.isKinematic = true;
            MyBody.constraints = RigidbodyConstraints.FreezeAll;
            transform.localScale += IncrementAmount;

            if (transform.localScale.x > StartScale.x)
            {
                FullyGrown = true;
            }
        }

        if(FullyGrown == true)
        {
            MyBody.constraints = RigidbodyConstraints.None;
            GetComponent<VirtualGravity>().enabled = true;
            MyBody.isKinematic = false;

        }


    }

   
}
