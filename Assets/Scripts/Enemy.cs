﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float rotOffset = 90.0f;

    [SerializeField] private Transform target;
    private float chaseRangeLow = 0.6f;
    private float chaseRangeHigh = 10.0f;

    [SerializeField]
    private Transform destination;
    NavMeshAgent navMeshAgent;


    // Use this for initialization
    void Start()
    {
        CheckAgent();
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
            // transform.Translate(Vector3.up * Time.deltaTime * speed);

            //Move towards target
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }

    }
    private void CheckAgent()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            enemyChase();
        }
    }
}
               



