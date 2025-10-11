using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public float stopDistance = 1.5f; // –ассто€ние, на котором враг останавливаетс€
    public int damage = 10;
    public float attackRate = 1f; // раз в секунду
    private float nextAttackTime = 0f;
    float StartScale;

    void Start()
    {
        StartScale = Mathf.Abs(transform.localScale.x);
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = stopDistance; // ”станавливаем дистанцию остановки

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Transform playerTransform = GameManager.Instance.player.transform;
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance > stopDistance)
        {
            agent.SetDestination(playerTransform.position);
            if (animator != null)
                animator.SetBool("1_Move", true);
        }
        else
        {
            agent.ResetPath(); // ќстанавливаем движение
            if (animator != null)
                animator.SetBool("1_Move", false);

            // јтака игрока, если р€дом и прошло достаточно времени
            if (Time.time >= nextAttackTime)
            {
                HP playerHP = GameManager.Instance.player.GetComponent<HP>();
                if (playerHP != null)
                {
                    playerHP.health -= damage;
                    nextAttackTime = Time.time + attackRate;
                }
            }
        }
        if (GameManager.Instance.player.transform.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(StartScale, StartScale, StartScale);
        }
        else if (GameManager.Instance.player.transform.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(-StartScale, StartScale, StartScale);
        }
    }
}
