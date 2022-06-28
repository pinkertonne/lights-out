using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(player.transform.position);
    }
}
