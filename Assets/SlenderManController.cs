using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlenderManController : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        InvokeRepeating(nameof(FindTarget), 0f, 1f);
       
;    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FindTarget() {

        navMeshAgent.destination = target.position;
    }
}
