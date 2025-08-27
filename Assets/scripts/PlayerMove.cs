using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float V = Input.GetAxis("Vertical");
        float H = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(H, V).normalized * speed;
        if (H > 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        else 
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        
    }

}
