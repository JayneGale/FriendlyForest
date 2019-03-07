using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogWayfinder : MonoBehaviour {

   // [SerializeField]
   // Transform nextWaypoint;

    [SerializeField]
    List<DrawGizmo> dogWayPoints;

    bool dogMoving;
  //  bool dogWaiting;
    bool waiting;
    float waitTime;
    public float totalWaitTime;
    public int startWayPointIndex;
    int currentWayPointIndex;

    NavMeshAgent navmeshAgent;


	// Use this for initialization
	void Start ()
    {
        navmeshAgent = this.GetComponent<NavMeshAgent>();
        Debug.Log(" dogWayPoints.Count is " + dogWayPoints.Count);

        if (navmeshAgent == null)
        {
            Debug.LogError("NavmeshAgent component is not attached to " + gameObject.name);                
        }
        else
        {
            if (dogWayPoints != null && dogWayPoints.Count >= 2)
            {
                currentWayPointIndex = startWayPointIndex;
                SetDestination();
            }
            else
            {
                Debug.LogError("Insufficient Waypoints attached to " + gameObject.name);
            }
        }
             		
	}

    public void Update()
    {
        if(dogMoving && navmeshAgent.remainingDistance <= 1.0f)
        {
            dogMoving = false;
            if (waiting)
            {
                waiting = true;
                waitTime = 0.0f;
            }
            else
            {
                ChangeWaypoint();
                SetDestination();
            }
            if (waiting)
            {
                waitTime += Time.deltaTime;
                if(waitTime >= totalWaitTime)
                {
                    waiting = false;
                    ChangeWaypoint();
                    SetDestination();
                }
            }
        }
    
    }

    private void ChangeWaypoint()
    {
        currentWayPointIndex = (currentWayPointIndex + 1) % dogWayPoints.Count;
    }

    private void SetDestination()
    {
        if (dogWayPoints != null)
        {
            Vector3 targetVector = dogWayPoints[currentWayPointIndex].transform.position;
            navmeshAgent.SetDestination(targetVector);
            dogMoving = true;
        }
    }

  }
