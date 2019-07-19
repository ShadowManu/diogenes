﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private NavMeshAgent nmAgent;

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = gameObject.GetComponent<NavMeshAgent>();
    }


    /* Moves the unit to a point */
    public void moveTo(Vector3 point) 
    {
        nmAgent.SetDestination(point);
    }

    public void enableMoving()
    {
        nmAgent.isStopped = false;
    }


    public void disableMoving()
    {
        nmAgent.isStopped = true;
    }
}
