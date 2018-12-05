using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 10.0f;
    [SerializeField] private float rotOffset = 90.0f;
    private Transform currentPatrolPoint;
    private int currentPatrolIndex;

    [SerializeField] private Transform target;
    private float chaseRangeLow = 1.0f;
    private float chaseRangeHigh = 10.0f;


    // Use this for initialization
    void Start()
    {
       
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
        enemyChase();
    }

    void enemyChase()
    {
        //Chase Player 
        //Get the distance to the target and check to see if it is close enough to chase
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < chaseRangeHigh && distanceToTarget > chaseRangeLow)
        {
            //Start chasing the target - turn and move towards the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.z, targetDir.x) * Mathf.Rad2Deg - rotOffset;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Euler(90.0f, transform.rotation.y, angle);
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        }
    
}
               



