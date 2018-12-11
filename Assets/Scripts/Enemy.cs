using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    [SerializeField] private Transform target;
    [SerializeField] private float chaseRangeLow = 0.6f;
    [SerializeField] private float chaseRangeHigh = 10.0f;

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
               



