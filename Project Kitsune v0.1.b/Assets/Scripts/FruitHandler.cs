using UnityEngine;
using System.Collections;

public class FruitHandler : MonoBehaviour
{
    [HideInInspector]
    public float GrowTime = new float();
    Vector3 HomePosition = new Vector3();
    Vector3 StartScale = new Vector3();
    Vector3 IncrementAmount = new Vector3(0.007f, 0.007f, 0.007f);
    Vector3 ScapegoatLocalScale = new Vector3();

    public float BouncePlay;

    float g_Time = 0.0f;
    bool FullyGrown = false;
    bool IsActive = true;

    bool BounceOne = true;
    bool BounceTwo = true;
    bool BounceThree = true;

    Rigidbody MyBody;

    void Start()
    {
        Rigidbody ThisBody = GetComponent<Rigidbody>();

        ThisBody.mass = Random.Range(0.005f, 0.008f);
      // ThisBody.drag = Random.Range(0.04f, 0.06f);

        HomePosition = transform.position;
        StartScale = transform.localScale;
       
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        ScapegoatLocalScale = transform.localScale;
        GrowTime += Random.Range(0.1f, 2.1f);
    }

    void OnCollisionEnter(Collision col)
    {
        Rigidbody konoBody = GetComponent<Rigidbody>();
        Vector3 ForceDirection = new Vector3(0.0f, BouncePlay, 0.0f);

        if(BounceOne == true)
        {
            ForceDirection.y = ForceDirection.y / 1.5f;
            konoBody.AddForce(ForceDirection * (Time.deltaTime * 100), ForceMode.Force);
            BounceOne = false;
        }
        else if (BounceTwo == true)
        {
            ForceDirection.y = ForceDirection.y /2;
            konoBody.AddForce(ForceDirection * (Time.deltaTime * 100), ForceMode.Force);
            BounceTwo = false;
        }
        else if (BounceThree == true)
        {
            ForceDirection.y = ForceDirection.y / 3;
            konoBody.AddForce(ForceDirection * (Time.deltaTime * 100), ForceMode.Force);
            BounceThree = false;
        }
        else
        {
            IsActive = false;
            BounceOne = true;
            BounceTwo = true;
            BounceThree = true;
        }
      
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
