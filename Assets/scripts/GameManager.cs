using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public GameObject player;
    public static GameManager Instance;
    public bool IsMobile;

    private void Awake()
    {
        Instance = this;
    }
   
}
