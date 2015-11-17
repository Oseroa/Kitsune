using UnityEngine;
using System.Collections;

public class PetalMenuScript : MonoBehaviour {

    public float speed = 1;

    // Use this for initialization
    void Start ()
    {
        transform.position = new Vector3(Random.Range(1920, 1970), Random.Range(0, 1080), 0);
        speed = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update ()
    {
        transform.position -= new Vector3(1 * speed, 0, 0);
        if (transform.position.x <= -3)
        {
            transform.position = new Vector3(Random.Range(1920, 1970), Random.Range(0, 1080), 0);
            speed = Random.Range(1, 5);
        }
    }
}
