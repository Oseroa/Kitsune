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

        //debug later
        if (GetComponent<PlayerManager>().IsGrounded == true && Mathf.Abs(rb.velocity.x) < Velocity)
        {
            rb.AddForce(RigidbodyMod * (Velocity * 100 / JumpControl) * Time.deltaTime, ForceMode.Acceleration);
            if (Mathf.Abs(rb.velocity.x) > 20.0f)
            {
                if (rb.velocity.x < 0)
                {
                    rb.velocity = new Vector3(Velocity, rb.velocity.y, rb.velocity.z);
                }

                else
                {
                    rb.velocity = new Vector3(Velocity, rb.velocity.y, rb.velocity.z);
                }
            }

            rb.AddForce(RigidbodyMod * (Velocity * 100) * Time.deltaTime, ForceMode.Impulse);
        }

        //Standard Movement
        else
        {
            rb.AddForce(RigidbodyMod * (Velocity * 10) * Time.deltaTime, ForceMode.Impulse);

            if (Mathf.Abs(rb.velocity.x) > Velocity)
            {
                if (rb.velocity.x < 0)
                {
                    rb.velocity = new Vector3(-Velocity, rb.velocity.y, rb.velocity.z);
                }

                else
                {
                    rb.velocity = new Vector3(Velocity, rb.velocity.y, rb.velocity.z);
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
