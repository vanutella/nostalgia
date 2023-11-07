using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoints : MonoBehaviour
{
    [SerializeField] private List<GameObject> wayPoints;
    private int index = 0;
    [SerializeField] private float speed = 3;

    void Update()
    {
        MoveTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
        Vector3 destination = wayPoints[index].transform.position;
        //Vector3 TargetPosition = new Vector3(wayPoints[index].transform.position.x, wayPoints[index].transform.position.y, wayPoints[index].transform.position.z);
        //transform.LookAt(TargetPosition);

        
        float singleStep = speed * Time.fixedDeltaTime;
        var targetRot = transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.position, targetRot, singleStep, 0f);

        // only rotate on y-axis
       // newDir.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-newDir), 4f * Time.deltaTime);



        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if(distance <= 0.5)
        {
            if (index < wayPoints.Count - 1)
            {
                targetRot = wayPoints[index].transform.position - transform.position;
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }
}
