using UnityEngine;
using System.Collections;

public class Wind_R : MonoBehaviour
{
    float s_Time;
    float x_Value = 0.0f;
    float y_Value = 0.0f;
    float z_Value = 0.0f;
    
   

    Vector3 ConstantPhysics = new Vector3(0.0f,0.0f,0.0f);

 
    void FixedUpdate()

    {
        s_Time += Time.deltaTime;
        if (s_Time > 1.4f)
        {
            Physics.gravity = ConstantPhysics;
            x_Value = Random.Range(-5.5f, 1.5f);
            y_Value = Random.Range(-.9f, 0.9f);
            z_Value = Random.Range(0.0f, 0.0f);
            
            Physics.gravity = new Vector3(x_Value, y_Value, z_Value);

            s_Time = 0.0f;
        }

    
    }
}
