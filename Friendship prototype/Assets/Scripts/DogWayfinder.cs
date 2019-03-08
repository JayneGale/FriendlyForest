using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogWayfinder : MonoBehaviour {

    // [SerializeField]
    // Transform nextWaypoint;

    [SerializeField]
    int zonePlayerIsIn;
    //    bool dogMarkingPlace;

    [SerializeField]
    int nextRightZone;
   // float totalWaitTime = 3.0f;
    [SerializeField]
    List<DrawGizmo> dogWayPoints;

    //is the dog moving towards its destination
    bool dogMoving;
    //is the dog waiting at the current destination
    bool waiting;
    // do we want the dog waiting at all - could get rid of this
    bool markingPlace;

    float waitTimer;
    public int startWayPointIndex;
    int currentWayPointIndex;
    Transform player;

    NavMeshAgent navmeshAgent;

	void Start ()
    {
        navmeshAgent = this.GetComponent<NavMeshAgent>();
        Debug.Log(" dogWayPoints.Count is " + dogWayPoints.Count);
  //      player = GameObject.FindGameObjectWithTag("Player").transform;

        if (navmeshAgent == null)
        {
            Debug.LogError("NavmeshAgent component is not attached to " + gameObject.name);                
        }
        else
        {
//            if (dogWayPoints != null && dogWayPoints.Count >= 2)
            if (dogWayPoints != null && dogWayPoints.Count >= 1)
                {
                currentWayPointIndex = startWayPointIndex;
                SetDestination();
            }
            else
            {
                Debug.LogError("No Waypoint attached to " + gameObject.name);
            }
        }
	}

    public void Update()
    {
        if (dogMoving && navmeshAgent.remainingDistance <= 1.0f)
        {
            dogMoving = false;
        }
            ChangeWaypoint();
            SetDestination();
            /*            if (markingPlace)
                        {
                            waiting = true;
                            waitTimer = 0.0f;
                        }
                        else
                        {
                            ChangeWaypoint();
                            SetDestination();
                        }
           */
        }
/*
        if (waiting)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= totalWaitTime)
            {
                waiting = false;
                ChangeWaypoint();
                SetDestination();
            }
        }
    
    }
 */
     
    private void ChangeWaypoint()
    {
        currentWayPointIndex = (currentWayPointIndex + 1);
        if (currentWayPointIndex >= dogWayPoints.Count)
        {
            currentWayPointIndex = dogWayPoints.Count-1;
        }
 //           currentWayPointIndex = (currentWayPointIndex + 1) % dogWayPoints.Count;
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
