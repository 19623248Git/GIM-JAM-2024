using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Debug.Log(agent.navMeshOwner);
        agent.SetDestination(player.transform.position);
        agent.stoppingDistance = 0.1f; // Set a small stopping distance
        agent.autoBraking = true; // Enable auto braking when reaching the destination

    }

    void OnDestinationReached()
    {
        // Handle destination reached event
        Debug.Log("Destination reached!");
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.1f)
        {
            OnDestinationReached();
        };
    }
}
