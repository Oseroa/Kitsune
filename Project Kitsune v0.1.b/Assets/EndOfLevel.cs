using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour
{

    public string AddSceneToLoad;

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            Application.LoadLevel(AddSceneToLoad);
        }
    }
	
}
