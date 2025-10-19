using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioSource musicSource;     // ���� � ���������� ������ AudioSource � �������
    public float detectionRadius = 10f; // ������, � ������� ���� ������

    void Update()
    {
        // ���� ���� ������ ����������
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

        // �������� ��� ��������� ������
        if (enemyNearby && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
        else if (!enemyNearby && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    // ����� ���������� ������ � ���������
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
