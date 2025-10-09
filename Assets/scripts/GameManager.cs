using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public GameObject player;
    public static GameManager Instance;
    public bool IsMobile;
    public List<GameObject> PlayersList = new();
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
