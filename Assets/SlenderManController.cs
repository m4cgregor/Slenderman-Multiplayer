using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class SlenderManController : NetworkBehaviour
{

    private NavMeshAgent navMeshAgent;
    private GameObject currentTarget;
    public float trackingRate = 2f;
    
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    [ClientRpc]
    public void RpcSetTarget(GameObject _target) {

        Debug.Log("New Target Selected");
        currentTarget = _target;
        InvokeRepeating(nameof(FollowTarget), 0, trackingRate);
        
     }

    void FollowTarget() {

        Debug.Log("Path finding");
        navMeshAgent.destination = currentTarget.transform.position;
    }



    
}
