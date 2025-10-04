using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] Joystick jk;
    [SerializeField] GameObject AttackButton;
    float StartScale;

    // Start is called before the first frame update
    void Start()
    {
        StartScale = Mathf.Abs(transform.localScale.x);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        if (!GameManager.Instance.IsMobile)
        {
            if (jk != null)
            {
                jk.gameObject.SetActive(false);
            }
            if (AttackButton != null)
            { AttackButton.SetActive(false); }
        }
    }

    public void attack()
    {
        anim.SetTrigger("2_Attack");
    }



    public void Update()
    {
        if (!GameManager.Instance.IsMobile)
        {
           if (Input.GetMouseButtonDown(0))
            {
                attack();
            }
        }
    }

    private void FixedUpdate()
    {
        float V = 0;
        float H = 0;
        if (GameManager.Instance.IsMobile)
        {
            V = jk.Vertical;
            H = jk.Horizontal;
        }

        else
        {
            V = Input.GetAxis("Vertical");
            H = Input.GetAxis("Horizontal");
        }

        rb.velocity = new Vector2(H, V).normalized * speed;
        if (H > 0)
        {
            transform.localScale = new Vector3(-StartScale, StartScale, StartScale);
        }
        else if (H < 0)
        {
            transform.localScale = new Vector3(StartScale, StartScale, StartScale);
        }
        Debug.Log(rb.velocity.magnitude);
        if (V != 0 || H != 0)
        {
            anim.SetBool("1_Move", true);
        }
        else
        {
            anim.SetBool("1_Move", false);
        }




    }

}
