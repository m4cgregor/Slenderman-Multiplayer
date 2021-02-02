using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class SlenderManController : NetworkBehaviour
{

    public NavMeshAgent navMeshAgent;
    public GameObject currentTarget;
    
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    [ClientRpc]
    public void RpcSetDestination(GameObject _target) {

        Debug.Log("New Target Selected");
        currentTarget = _target;
        InvokeRepeating(nameof(FollowTarget), 0, 2f);
        
     }

    void FollowTarget() {

        Debug.Log("Path finding");
        navMeshAgent.destination = currentTarget.transform.position;
    }



    
}
