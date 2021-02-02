using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class SlenderManController : NetworkBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Vector3 currentTarget;
    
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    [ClientRpc]
    public void RpcSelectTarget(Vector3 _target) {

        currentTarget = _target;
        InvokeRepeating(nameof(FindTarget), 0f, 1f);
    }


    void FindTarget() {

        navMeshAgent.destination = currentTarget;
    }

    
}
