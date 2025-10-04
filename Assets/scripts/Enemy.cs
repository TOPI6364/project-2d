using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public float stopDistance = 1.5f; // ����������, �� ������� ���� ���������������
    public int damage = 10;
    public float attackRate = 1f; // ��� � �������
    private float nextAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = stopDistance; // ������������� ��������� ���������
    }

    void Update()
    {
        Transform playerTransform = GameManager.Instance.player.transform;
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance > stopDistance)
        {
            agent.SetDestination(playerTransform.position);
        }
        else
        {
            agent.ResetPath(); // ������������� ��������

            // ����� ������, ���� ����� � ������ ���������� �������
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
    }
}
