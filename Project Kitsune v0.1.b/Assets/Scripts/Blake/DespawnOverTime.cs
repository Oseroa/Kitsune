using UnityEngine;
using System.Collections;

public class DespawnOverTime : MonoBehaviour

{
    float l_Time = 0.0f;

	void Update ()
    {
        l_Time += Time.deltaTime;



       
        if(l_Time > 1)
        {

            
           
            // Destroy(gameObject);
        }
	}
}
