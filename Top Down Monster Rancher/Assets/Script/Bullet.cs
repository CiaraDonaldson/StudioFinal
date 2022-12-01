using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
       //rb.AddForce(Vector2.right * 7);

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
