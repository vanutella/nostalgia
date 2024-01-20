using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoints : MonoBehaviour
{
    [SerializeField] private List<GameObject> wayPoints;
    private int index = 0;
    [SerializeField] private float speed = 3;
    [SerializeField] private float rotationSpeed = 2f;
    string myString = "1";

    private void Awake()
    {
        
    }
    void Update()
    {
        MoveTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
        Vector3 destination = wayPoints[index].transform.position;
        
        float singleStep = speed * Time.fixedDeltaTime;


        var targetRot = transform.position - destination;
      //  Vector3 newDir = Vector3.RotateTowards(transform.position, targetRot, singleStep, 0f);
        //Vector3 newDir = Vector3.RotateTowards(transform.position, destination, singleStep, 0f);

        // only rotate on y-axis
        // newDir.y = 0;

       // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-newDir), 4f * Time.deltaTime);


        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        RotateTowardsDestination(index);
        float distance = Vector3.Distance(transform.position, destination);
        if(distance <= 0.5)
        {
            if (index < wayPoints.Count - 1)
            {
                //targetRot = wayPoints[index].transform.position - transform.position;
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }

    private void RotateTowardsDestination(int index)
    {
        Vector3 targetDirection = wayPoints[index].transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
