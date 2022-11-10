using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private float timeToChangeDirection;
    public Rigidbody2D rigidbody;

    public void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

  
    public void Update()
    {
        timeToChangeDirection -= Time.deltaTime;

        if (timeToChangeDirection <= 0)
        {
            ChangeDirection();
        }

        rigidbody.velocity = transform.up * 2;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            ChangeDirection();
        } 
        if (collision.gameObject.tag == "Room")
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        float angle = Random.Range(0f, 360f);
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 newUp = quat * Vector3.up;
        newUp.z = 0;
        newUp.Normalize();
        transform.up = newUp;
        timeToChangeDirection = 1.5f;
    }
}
