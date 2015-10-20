using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour
{
    public GameObject g_Spawn;
    Vector3 SpawnPos;
	void Start ()
    {
        SpawnPos = transform.position;
	}
	
	
	void FixedUpdate ()
    {
        float rPos = Random.Range(1,1);
        SpawnPos.x += rPos;
        SpawnPos.y += rPos;
        Instantiate(g_Spawn, SpawnPos,transform.rotation);
        
	}
}
