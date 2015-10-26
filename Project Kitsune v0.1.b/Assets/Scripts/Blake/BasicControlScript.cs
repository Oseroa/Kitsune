using UnityEngine;
using System.Collections;

public class BasicControlScript : MonoBehaviour
{

    public float Velocity;
    //public float MaxSpeed;
    public float ExponentialJumpModifier;
    public float JumpPower;
    public float JumpControl;
    public float TimeBetweenJumps;
    float l_Time = 100.0f;
    bool IsGliding = false;

    private float ExponentialJump = new float();
    private bool f_Jump = false;

    private float Jump1 = 2.0f;
    private float Jump2 = 2.2f;
    private float Jump3 = 2.4f;
    private float Jump4 = 2.6f;

    Vector3 MousePosition = new Vector3();

    void FixedUpdate()
    {
        l_Time += Time.deltaTime;


        Vector3 RigidbodyMod = new Vector3();
        RigidbodyMod.x = Input.GetAxis("Horizontal");
        Rigidbody rb = GetComponent<Rigidbody>();
        TrailRenderer tr = GetComponent<TrailRenderer>();
        //Vector3 VelocityCheck = rb.velocity;

        if(Input.GetButton("Glide") == false)
        {
            GetComponent<PlayerGlide>().enabled = false;
            GetComponent<TrailRenderer>().enabled = false;
            IsGliding = false;
        }

        if (Input.GetButton("Jump") && gameObject.GetComponent<PlayerManager>().NumberOfJumps > 0)
        {
            tr.enabled = false;
            rb.useGravity = false;
            MousePosition = Input.mousePosition;
            MousePosition.z = 20;

            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
            Vector3 RelativePosition = MousePosition - transform.position;

            if (GetComponent<PlayerManager>().NumberOfJumps == GetComponent<PlayerManager>().MaxNumberOfJumps)
            {
                f_Jump = false;
            }


            if (l_Time > TimeBetweenJumps && IsGliding == false)
            {
                if(f_Jump == false)
                {
                    ExponentialJump = JumpPower;
                    f_Jump = true;
                }

               else if (f_Jump == true)
                {
                    ExponentialJump *= ExponentialJumpModifier;
                }

                rb.AddForce(-RelativePosition.normalized * (ExponentialJump * 100) * Time.deltaTime, ForceMode.Impulse);
                gameObject.GetComponent<PlayerManager>().NumberOfJumps -= 1;
                l_Time = 0.0f;
                GetComponent<PlayerGlide>().enabled = false;
            }

        }

        //Glide After Jump
        if (Input.GetButton("Glide"))
        {
            GetComponent<PlayerGlide>().enabled = true;
            GetComponent<TrailRenderer>().enabled = true;
            IsGliding = true;
        }

       
        if(Mathf.Abs(rb.velocity.y) > 1.0f)
        {
            rb.AddForce(RigidbodyMod * (Velocity) * Time.deltaTime, ForceMode.Impulse);

            if(GetComponent<PlayerManager>().NumberOfJumps == GetComponent<PlayerManager>().MaxNumberOfJumps)
            {
                if (rb.velocity.x < -Velocity * Jump1)
                {
                    rb.velocity = new Vector3(Mathf.Lerp(-Velocity * Jump1, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
               
                }

                else if (rb.velocity.x > Velocity * Jump1)
                {
                    rb.velocity = new Vector3(Mathf.Lerp(Velocity * Jump1, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
                    // rb.velocity = new Vector3((Velocity) * 1.5f, rb.velocity.y, rb.velocity.z);
                }
            }
            else if (GetComponent<PlayerManager>().NumberOfJumps == GetComponent<PlayerManager>().MaxNumberOfJumps - 1)
            {
                if (rb.velocity.x < -Velocity * Jump2)
                {
                    
                    rb.velocity = new Vector3(Mathf.Lerp(-Velocity * Jump2, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
                }

                else if (rb.velocity.x > Velocity * Jump2)
                {
                    rb.velocity = new Vector3(Mathf.Lerp(Velocity * Jump2, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
                }
            }
            else if (GetComponent<PlayerManager>().NumberOfJumps == GetComponent<PlayerManager>().MaxNumberOfJumps - 2)
            {
                if (rb.velocity.x < -Velocity * Jump3)
                {
                    //rb.velocity = new Vector3((-Velocity) * 1.8f, rb.velocity.y, rb.velocity.z);
                    rb.velocity = new Vector3(Mathf.Lerp(-Velocity * Jump3, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
                }

                else if (rb.velocity.x > Velocity * Jump3)
                {
                    rb.velocity = new Vector3(Mathf.Lerp(Velocity * Jump3, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
                }
            }
            else if (GetComponent<PlayerManager>().NumberOfJumps == GetComponent<PlayerManager>().MaxNumberOfJumps - 3)
            {
                if (rb.velocity.x < -Velocity * Jump4)
                {
                    //rb.velocity = new Vector3((-Velocity) * 1.8f, rb.velocity.y, rb.velocity.z);
                    rb.velocity = new Vector3(Mathf.Lerp(-Velocity * Jump4, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
                }

                else if (rb.velocity.x > Velocity * Jump4)
                {
                    rb.velocity = new Vector3(Mathf.Lerp(Velocity * Jump4, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
                }
            }


        }

        else
        {
            rb.AddForce(RigidbodyMod * (Velocity * 10) * Time.deltaTime, ForceMode.Impulse);

            if (Mathf.Abs(rb.velocity.x) > Velocity) 
            {
                if (rb.velocity.x < -Velocity)
                {
                    rb.velocity = new Vector3(-Velocity, rb.velocity.y, rb.velocity.z);
                   // rb.velocity = new Vector3(Mathf.Lerp(-Velocity *2, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
                }

                else if(rb.velocity.x > Velocity)
                {
                     rb.velocity = new Vector3(Velocity, rb.velocity.y, rb.velocity.z);
                   // rb.velocity = new Vector3(Mathf.Lerp(Velocity *2, rb.velocity.x, Time.deltaTime), rb.velocity.y, rb.velocity.z);
                }
            }

        }

        if (Input.GetButton("LoadToCheckpoint"))
        {
            transform.position = GetComponent<PlayerManager>().CurrentCheckPoint;
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }


    }
}
