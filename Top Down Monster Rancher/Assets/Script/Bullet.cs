using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * 7);
    }

    // Update is called once per frame
    void Update()
    {
       rb.AddForce(Vector2.right * 7);

        Destroy(this.gameObject, 3f);
    }

    void onTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Enemy")
        {
            Debug.Log("Hurt");
           // EnemyMovement.counter += 1;

        }

    }
}
