using UnityEngine;
using System.Collections;

public class SpiritSplit : MonoBehaviour
{
    public GameObject SplitSpirit;

    GameObject ClonedSpirit;

    float CoolDownTime = 2;
    float l_Time;
    bool EventFlipper = false;
    bool ActiveClone = false;

    void FixedUpdate()
    {
        l_Time += Time.deltaTime;
      

        if (Input.GetButton("SplitSpirit") && l_Time > CoolDownTime)
        {
            
           if (EventFlipper == true && ActiveClone == true)
            {
               
                transform.position = ClonedSpirit.transform.position;
                Destroy(ClonedSpirit);
                EventFlipper = false;
                l_Time = 0.0f;
                ActiveClone = false;

          
            }

            else if (EventFlipper == true)
            {
         
                Destroy(ClonedSpirit);
                ClonedSpirit = Instantiate(SplitSpirit, transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
                l_Time = 0.0f;
                ActiveClone = true;
                EventFlipper = false;
            }
            EventFlipper = true;

        }

    }
}
