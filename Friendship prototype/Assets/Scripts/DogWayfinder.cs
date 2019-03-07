using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogWayfinder : MonoBehaviour {

    [SerializeField]
    Transform nextWaypoint;
    //[SerializeField]
    //   Transform waypointAfterThat;
    NavMeshAgent navmeshAgent;


	// Use this for initialization
	void Start () {
        navmeshAgent = this.GetComponent<NavMeshAgent>();
        nextWaypoint = nextWaypoint.GetComponent<Transform>();
        Debug.Log("Navmesh script started");
        float zpos = nextWaypoint.transform.position.z;
        float xpos = nextWaypoint.transform.position.x;
        Debug.Log("Target x position is " + xpos);
        Debug.Log("Target z position is " + zpos);
        if (navmeshAgent == null)
        {
            Debug.LogError("NavmeshAgent component is not attached to " + gameObject.name);                
        }
        else
        {
            SetDestination();
        }
             		
	}

    private void SetDestination()
    {
        if (nextWaypoint != null)
        {
            Vector3 targetVector = nextWaypoint.transform.position;
            navmeshAgent.SetDestination(targetVector);
        }
    }

  }
