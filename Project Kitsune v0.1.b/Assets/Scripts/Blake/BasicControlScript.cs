using UnityEngine;
using System.Collections;
using XboxCtrlrInput;


//Controller Input for xbox using https://github.com/JISyed/Unity-XboxCtrlrInput
public class BasicControlScript : MonoBehaviour
{

    public float Velocity;
    public float ExponentialJumpModifier;
    public float JumpPower;
    public float JumpControl;
    public float TimeBetweenJumps;
    float l_Time = 100.0f;
    bool IsGliding = false;
    float j_Time = 0.0f;
    float JumpResetTimer = 0.5f;
    bool RecentlyJumped = false;

    private float ExponentialJump = new float();
    private bool f_Jump = false;
    Vector3 MousePosition = new Vector3();
    Vector3 ControllerPosition = new Vector3();

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        Vector3 KonoDownwardVector = transform.TransformDirection(Vector3.down);
        Vector3 KonoRightwardBector = transform.TransformDirection(Vector3.right);
        Vector3 KonoLeftwardBector = transform.TransformDirection(Vector3.left);

        if (!Physics.Raycast(transform.position, KonoLeftwardBector, 1) && !Physics.Raycast(transform.position, KonoRightwardBector, 1))
        {
            l_Time += Time.deltaTime;
            j_Time += Time.deltaTime;

            Vector3 RigidbodyMod = new Vector3();
            RigidbodyMod.x = Input.GetAxis("Horizontal");
            Rigidbody rb = GetComponent<Rigidbody>();
            TrailRenderer tr = GetComponent<TrailRenderer>();

            if (Input.GetButton("Glide") == false)
            {
                //GetComponent<PlayerGlide>().enabled = false;
                GetComponent<TrailRenderer>().enabled = false;
                IsGliding = false;
            }
            if (Input.GetButton("Jump") || XCI.GetButton(XboxButton.RightBumper))
            {
                if (gameObject.GetComponent<PlayerManager>().NumberOfJumps > 0)
                {
                    tr.enabled = false;
                    rb.useGravity = false;

                    Vector3 RelativePosition;
                    if (XCI.IsPluggedIn(1))
                    {
                        ControllerPosition.x = XCI.GetAxisRaw(XboxAxis.RightStickX) * 100;
                        ControllerPosition.y = XCI.GetAxisRaw(XboxAxis.RightStickY) * 100;
                        ControllerPosition.z = 0.0f;
                        ControllerPosition.x = ControllerPosition.x * -1.0f;
                        ControllerPosition.y = ControllerPosition.y * -1.0f;
                        RelativePosition = ControllerPosition - transform.position.normalized;


                        if (GetComponent<PlayerManager>().NumberOfJumps == GetComponent<PlayerManager>().MaxNumberOfJumps)
                        {
                            f_Jump = false;
                        }

                        if (l_Time > TimeBetweenJumps && IsGliding == false)
                        {
                            if (f_Jump == false)
                            {
                                ExponentialJump = JumpPower;
                                f_Jump = true;
                            }

                            else if (f_Jump == true)
                            {
                                ExponentialJump *= ExponentialJumpModifier;
                            }

                            rb.AddForce(RelativePosition.normalized * (ExponentialJump * 20) * Time.deltaTime, ForceMode.VelocityChange);
                            gameObject.GetComponent<PlayerManager>().NumberOfJumps -= 1;
                            l_Time = 0.0f;
                            GetComponent<PlayerGlide>().enabled = false;
                        }
                    }
                    else
                    {
                        MousePosition = Input.mousePosition;
                        MousePosition.z = 20;

                        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
                        RelativePosition = transform.position - MousePosition;

                        if (GetComponent<PlayerManager>().NumberOfJumps == GetComponent<PlayerManager>().MaxNumberOfJumps)
                        {
                            f_Jump = false;
                        }

                        if (l_Time > TimeBetweenJumps && IsGliding == false)
                        {
                            if (f_Jump == false)
                            {
                                ExponentialJump = JumpPower;
                                f_Jump = true;
                            }

                            else if (f_Jump == true)
                            {
                                ExponentialJump *= ExponentialJumpModifier;
                            }

                            rb.AddForce(RelativePosition.normalized * (ExponentialJump * 20) * Time.deltaTime, ForceMode.VelocityChange);
                            gameObject.GetComponent<PlayerManager>().NumberOfJumps -= 1;
                            l_Time = 0.0f;
                            GetComponent<PlayerGlide>().enabled = false;
                        }
                    }


                }
            }
            //Glide After Jump
            if (Input.GetButton("Glide"))
            {
                GetComponent<PlayerGlide>().enabled = true;
                GetComponent<TrailRenderer>().enabled = true;
                IsGliding = true;
            }

            Vector3 UpdatedMovement = RigidbodyMod;


      


            if (Mathf.Abs(rb.velocity.y) > 0.0f)
            {
                UpdatedMovement.x = ((UpdatedMovement.x * (Velocity) * Time.deltaTime));
            }

            else
            {
                UpdatedMovement.x = (UpdatedMovement.x * Velocity) * Time.deltaTime;
            }


            if (UpdatedMovement.x != 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(UpdatedMovement);
            }


            
            //Jump Reset
            if (Physics.Raycast(transform.position, KonoDownwardVector, 0.7f))
            {
                
                if(RecentlyJumped == false && j_Time > JumpResetTimer)
                {
                    GetComponent<PlayerManager>().NumberOfJumps = GetComponent<PlayerManager>().MaxNumberOfJumps;
                  
                    ExponentialJump = JumpPower;
                    RecentlyJumped = true;
                    j_Time = 0.0f;
                    
                }
                Vector3 NewVelocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
                rb.velocity = NewVelocity;
            
            }

            //In air stuff
            else
            {
                if(rb.velocity.x > 0.0f && UpdatedMovement.x > 0)
                {
                    rb.velocity += new Vector3(-1, 0, 0);
                }
                if (rb.velocity.x < 0.0f && UpdatedMovement.x > 0)
                {
                    rb.velocity += new Vector3(1,0,0);
                }


            }
            transform.position += UpdatedMovement;

            if (j_Time > JumpResetTimer)
            {
                RecentlyJumped = false;
            }

         

        }
   
   
    }
  
}

