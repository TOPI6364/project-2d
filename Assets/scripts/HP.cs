using System.Collections;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int health = 100; // ������� ���������� ��
    public float disappearDelay = 0.001f; // ����� �� ������������ ����� ������
    private Animator animator;
    private bool isDead = false;
    

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // �� ������� �� ������� K �������� �������
        if (Input.GetKeyDown(KeyCode.K) && !isDead)
        {
            Die();
        }

        // ���� �� <= 0, �������� �������
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        if (animator != null)
        {
            // ���������� ��� ��������� ���������, ����� �������� ������
            foreach (AnimatorControllerParameter param in animator.parameters)
            {
                if (param.type == AnimatorControllerParameterType.Bool)
                    animator.SetBool(param.name, false);
                if (param.type == AnimatorControllerParameterType.Trigger && param.name != "Death")
                    animator.ResetTrigger(param.name);
                if (param.type == AnimatorControllerParameterType.Float)
                    animator.SetFloat(param.name, 0f);
                if (param.type == AnimatorControllerParameterType.Int)
                    animator.SetInteger(param.name, 0);
            }
            animator.SetTrigger("Death");
        }

        // ��������� ��� ����������, ���������� �� ��������
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script != this && script.enabled)
            {
                script.enabled = false;
            }
        }

        // ������������� ������������� ���������� ��������
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        // ��������� �������� �� ������������ ����� �������� �����
        StartCoroutine(DisappearAfterDelay());
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(disappearDelay);
        Destroy(gameObject);
    }
}
