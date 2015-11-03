using UnityEngine;
using System.Collections;

public class BasicAIController : MonoBehaviour

{
    public GameObject NodeA;
    public GameObject NodeB;
    public GameObject PatrolArea;
    public float DefaultMovementSpeed;
    float movementSpeed;
    bool TargetAchieved = false;
    bool _firstRun = false;
    GameObject TargetNode;
    float randomRangeForPatrolNodes = 0.02f;
    float speedScale = 1;

    void Start()
    {
        movementSpeed = DefaultMovementSpeed;
    }

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
                RandomiseNextTargetPoint(NodeB);
                speedScale = 1;

            }

            else if (TargetNode == NodeA)
            {
                TargetNode = NodeB;
                TargetAchieved = false;
                RandomiseNextTargetPoint(NodeA);
                speedScale = 1;
             
            }

        }
        if (TargetNode.GetComponent<SphereCollider>().bounds.Intersects(GetComponent<SphereCollider>().bounds))
        {
            if(speedScale > 0.01) speedScale -= Time.deltaTime;
            movementSpeed = DefaultMovementSpeed * speedScale;
        }
        else
        {
            movementSpeed = DefaultMovementSpeed;
        }

        float MoveSpeed = movementSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, TargetNode.transform.position, MoveSpeed);

        if (transform.position.x > TargetNode.transform.position.x - 1 && transform.position.x < TargetNode.transform.position.x + 1)
        {
            TargetAchieved = true;
           
        }
    }

    void RandomiseNextTargetPoint(GameObject node)
    {
        float randomTempX = randomRangeForPatrolNodes * PatrolArea.transform.localScale.x;
        float randomTempY = randomRangeForPatrolNodes * PatrolArea.transform.localScale.y;
        node.transform.localPosition = new Vector3(Random.Range(-randomTempX, randomTempX), Random.Range(-randomTempY,randomTempY),0);
    }
}
