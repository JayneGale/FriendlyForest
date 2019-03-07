using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogWayfinder : MonoBehaviour {

    [SerializeField]
    Transform nextWaypoint;

 //   Transform waypointAfterThat;
    NavMeshAgent navmeshAgent;


	// Use this for initialization
	void Start () {
        navmeshAgent = this.GetComponent<NavMeshAgent>();
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
            Vector2 targetVector = nextWaypoint.transform.position;
            float zpos = nextWaypoint.transform.position.z;
            Debug.Log("Bone z position is " + zpos);
            navmeshAgent.SetDestination(targetVector);
        }
    }

  }
