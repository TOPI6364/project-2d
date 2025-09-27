using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sup : MonoBehaviour
{
    [SerializeField] float stopDistance = 2f;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = stopDistance;
    }
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = stopDistance;
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, GameManager.Instance.player.transform.position);
        if (distance > stopDistance)
        {
            agent.SetDestination(GameManager.Instance.player.transform.position);
        }
        else
        {
            agent.ResetPath();
        }
    }

}