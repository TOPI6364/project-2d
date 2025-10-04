using System.Collections;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int health = 100; // Текущее количество хп
    public float disappearDelay = 0.001f; // Время до исчезновения после смерти
    private Animator animator;
    private bool isDead = false;
    

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // По нажатию на клавишу K персонаж умирает
        if (Input.GetKeyDown(KeyCode.K) && !isDead)
        {
            Die();
        }

        // Если хп <= 0, персонаж умирает
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
            // Сбрасываем все параметры аниматора, кроме триггера смерти
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

        // Отключаем все компоненты, отвечающие за движение
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script != this && script.enabled)
            {
                script.enabled = false;
            }
        }

        // Принудительно останавливаем физическое движение
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        // Запускаем корутину на исчезновение через заданное время
        StartCoroutine(DisappearAfterDelay());
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(disappearDelay);
        Destroy(gameObject);
    }
}
