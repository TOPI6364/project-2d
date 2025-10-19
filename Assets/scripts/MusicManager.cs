using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioSource musicSource;     // Сюда в инспекторе добавь AudioSource с музыкой
    public float detectionRadius = 10f; // Радиус, в котором ищем врагов

    void Update()
    {
        // Ищем всех врагов поблизости
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        bool enemyNearby = false;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= detectionRadius)
            {
                enemyNearby = true;
                break;
            }
        }

        // Включаем или выключаем музыку
        if (enemyNearby && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
        else if (!enemyNearby && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    // Чтобы отобразить радиус в редакторе
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
