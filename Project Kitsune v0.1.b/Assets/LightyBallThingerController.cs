using UnityEngine;
using System.Collections;

public class LightyBallThingerController : MonoBehaviour
{
    float g_Time = 0.0f;
    float i_Time = 0.0f;
    Vector3 StartPosition = new Vector3();
    bool OnRespawn = false;
    Vector3 MovementVector = new Vector3();

    public float MaximumIncrementalDistance;

    void Start ()
    {
        StartPosition = transform.position;
	}

    
	void Update ()
    {
        g_Time += Time.deltaTime;
        i_Time += Time.deltaTime;

        //Vector3 NewMoveToward = new Vector3(Random.Range(-1.0f, 1.0f), (Random.Range(-1.0f, 1.0f)), (Random.Range(-1.0f, 1.0f)));



        Light KonoYagami = GetComponent<Light>();
        float IntensityModifier = Random.Range(0.7f, 2.0f);

        if (i_Time > Random.Range(0.7f, 1.2f))
        {
            KonoYagami.intensity = IntensityModifier;

            i_Time = 0.0f;
        }

        if (g_Time > Random.Range(0.7f, 2.6f))
        {
           MovementVector = new Vector3(transform.position.x + Random.Range(-50.0f, 50.0f), transform.position.y + Random.Range(-50.0f, 50.0f), transform.position.z + Random.Range(-50.0f, 50.0f));

            g_Time = 0.0f;
        }



       

        if (OnRespawn == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPosition, Time.deltaTime);
            if (transform.position == StartPosition)
            {
                OnRespawn = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, MovementVector, Time.deltaTime);
        }
       
        if (Mathf.Abs(transform.position.x) - Mathf.Abs(StartPosition.x) > MaximumIncrementalDistance)
        {
            OnRespawn = true;
        }
    }
}
