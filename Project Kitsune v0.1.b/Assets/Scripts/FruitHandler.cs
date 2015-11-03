using UnityEngine;
using System.Collections;

public class FruitHandler : MonoBehaviour
{
    public float GrowTime = new float();
    Vector3 HomePosition = new Vector3();
    Vector3 StartScale = new Vector3();
    Vector3 IncrementAmount = new Vector3(0.007f, 0.007f, 0.007f);
    Vector3 ScapegoatLocalScale = new Vector3();
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

        ScapegoatLocalScale = transform.localScale;
        GrowTime += Random.Range(0.1f, 2.1f);
    }

    void OnCollisionEnter(Collision col)
    {
        IsActive = false;
    }
    void Update()
    {
        g_Time += Time.deltaTime;
        MyBody = GetComponent<Rigidbody>();

        if(IsActive == false)
        {
            transform.localScale = ScapegoatLocalScale;
            transform.position = HomePosition;
            GetComponent<VirtualGravity>().enabled = false;
            MyBody.constraints = RigidbodyConstraints.FreezeAll;
            g_Time = 0.0f;
            FullyGrown = false;
        }


        if (g_Time < GrowTime && FullyGrown == false)
        {
            IsActive = true;
            GetComponent<VirtualGravity>().enabled = false;
           
            MyBody.constraints = RigidbodyConstraints.FreezeAll;
            transform.localScale = transform.localScale + IncrementAmount;

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
