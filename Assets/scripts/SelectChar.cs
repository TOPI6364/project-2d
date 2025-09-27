using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SelectChar : MonoBehaviour
{
    [SerializeField] GameObject Target;
    void OnMouseDown()
    {
        GameManager.Instance.player.GetComponent<Rigidbody2D>().simulated = false;
        GameManager.Instance.player.GetComponent<PlayerMove>().enabled = false;
        GameManager.Instance.player.GetComponent<NavMeshAgent>().enabled = true;
        GameManager.Instance.player.GetComponent<Sup>().enabled = true;
        GameManager.Instance.player = Target;
        GameManager.Instance.player.GetComponent<Rigidbody2D>().simulated = true;
        GameManager.Instance.player.GetComponent<PlayerMove>().enabled = true;
        GameManager.Instance.player.GetComponent<NavMeshAgent>().enabled = false;
        GameManager.Instance.player.GetComponent<Sup>().enabled = false;
        Debug.Log("Åùêåðå");
    }
    private void Update()
    {
        transform.position = Target.transform.position;
    }
    private void Start()
    {
        gameObject.transform.parent = null;
    }
}
