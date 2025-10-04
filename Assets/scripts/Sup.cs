using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sup : MonoBehaviour
{
    [SerializeField] float stopDistance = 2f;
    NavMeshAgent agent;
    Animator anim;
    float StartScale;

    void Start()
    {
        StartScale = transform.localScale.x;
        anim = GetComponentInChildren<Animator>();
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
        if (GameManager.Instance.player.transform.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(StartScale, StartScale, StartScale);
        }
        else if (GameManager.Instance.player.transform.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(-StartScale, StartScale, StartScale);
        }

        if (distance > stopDistance)
        {
            agent.SetDestination(GameManager.Instance.player.transform.position);
            anim.SetBool("1_Move", true);
        }
        else
        {
            agent.ResetPath();
            anim.SetBool("1_Move", false);
        }
    }

}