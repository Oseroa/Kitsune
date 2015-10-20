using UnityEngine;
using System.Collections;

public class BasicAIController : MonoBehaviour
{
    public GameObject NodeA;
    public GameObject NodeB;
    public float MovementSpeed;
    bool TargetAchieved = false;
    bool _firstRun = false;
    GameObject TargetNode;


    void LateUpdate()
    {
        
        if (_firstRun == false)
        {
            TargetNode = NodeB;
            _firstRun = true;
        }

        if (TargetAchieved == true)
        {
            if (TargetNode == NodeB)
            {
                TargetNode = NodeA;
                TargetAchieved = false;
                print("Node switched to A");
            }

            else if (TargetNode == NodeA)
            {
                TargetNode = NodeB;
                TargetAchieved = false;
                print("Node switched to B");
            }

        }

        float MoveSpeed = MovementSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, TargetNode.transform.position, MoveSpeed);

        if (transform.position.x > TargetNode.transform.position.x - 1 && transform.position.x < TargetNode.transform.position.x + 1)
        {
            TargetAchieved = true;
            print("ithappen");
        }
    }
}
