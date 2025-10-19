using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    public GameObject player;
    public static GameManager Instance;
    public bool IsMobile;
    public Image GameOver;
    public List<GameObject> PlayersList = new();
    [SerializeField] GameObject MobileButtons;
    public AudioSource musicSource;
    private void Awake()
    {
        Instance = this;
    }
    public void ChangeAfterDie(GameObject OldPlayer)
    {
        PlayersList.Remove(OldPlayer);

        if (PlayersList.Count == 0)
        {
            Debug.Log("All die");
            GameOver.gameObject.SetActive(true);
            MobileButtons.SetActive(false);
            musicSource.gameObject.SetActive(false);

        }
        else
        {
            player = PlayersList[0];

            player.GetComponent<Rigidbody2D>().simulated = true;
            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            player.GetComponent<Sup>().enabled = false;
        }
    }
}
