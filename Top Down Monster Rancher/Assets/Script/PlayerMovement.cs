using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;   
    public Vector2 movement;           
    public Rigidbody2D rigidbody;           
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       transform.position = new Vector2(0f, 0f);
        rigidbody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {

        rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
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

