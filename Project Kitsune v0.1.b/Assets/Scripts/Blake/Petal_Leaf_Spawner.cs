using UnityEngine;
using System.Collections;

public class Petal_Leaf_Spawner : MonoBehaviour
{
    Vector3 HomePosition = new Vector3();
    Vector3 StartScale = new Vector3();
    Quaternion StartRotation = new Quaternion();
    public Vector3 FinalScale = new Vector3();
    public float MaxDistance = new float();

    float l_Time;


    public float LeafGrowTime;

    float v_LeafGrowTime = new float();

    bool OnRespawnCycle = true;

    void Start()
    {
        Rigidbody ThisBody = GetComponent<Rigidbody>();

        ThisBody.mass = Random.Range(0.008f, 0.001f);
        ThisBody.drag = Random.Range(0.04f, 0.06f);
        HomePosition = transform.position;
        StartScale = transform.localScale;
        StartRotation = transform.rotation;
        v_LeafGrowTime = Random.Range(0.0f, 1.5f);

        LeafGrowTime = LeafGrowTime + v_LeafGrowTime;
    }


    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        l_Time += Time.deltaTime;
    
        float DistanceFromHome = Vector3.Distance(HomePosition, transform.position);


        if (l_Time < LeafGrowTime && OnRespawnCycle == true)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.localScale += new Vector3(0.001f, 0.001f, 0.0f);

            if(transform.localScale.x > FinalScale.x && transform.localScale.y > FinalScale.y)
            {
                transform.localScale = FinalScale;
                l_Time += LeafGrowTime;
            }

        }

        else if (l_Time > LeafGrowTime && OnRespawnCycle == true)
        {
            rb.useGravity = true;
            rb.freezeRotation = false;
            rb.constraints = RigidbodyConstraints.None;
            OnRespawnCycle = false;
          
        }

        if (OnRespawnCycle == false && DistanceFromHome > MaxDistance)
        {
            transform.localScale += new Vector3(-0.0001f, -0.0001f, 0.0f);
            

            if(transform.localScale.x > StartScale.x && transform.localScale.y > StartScale.y)
            {
                rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                transform.localScale = StartScale;
                transform.position = HomePosition;
                transform.rotation = StartRotation;
                rb.freezeRotation = true;
                rb.constraints = RigidbodyConstraints.FreezeAll;
      

                OnRespawnCycle = true;
                l_Time = 0.0f;
            }
        }


    }
}
