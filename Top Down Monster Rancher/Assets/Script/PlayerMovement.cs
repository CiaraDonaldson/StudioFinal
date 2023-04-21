using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;   
    public Vector2 movement;           
    public Rigidbody2D rb;           
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector2(0f, 0f);;
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
       

        rb.MovePosition(GetComponent<Rigidbody2D>().position + movement * movementSpeed * Time.fixedDeltaTime);

        if (movement.y < 0)
        {
            anim.Play("PlayerUp");
        }
        else if (movement.y > 0)
        {
            anim.Play("PlayerDown");
        }
        else if (movement.x < 0)
        {
            anim.Play("Player Left");
        }
        else if (movement.x > 0)
        {
            anim.Play("Player Right");
        }
        else 
        {
            anim.Play("Idle");
        }
    }
}

