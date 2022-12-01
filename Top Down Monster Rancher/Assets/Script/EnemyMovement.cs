using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 2f;
    private float minDistance = 1f;
    private float range;
    public int counter = 0;
    public Animator anim;
    public Rigidbody2D rb;
    public Transform[] roomTrans;
    public GameObject Blood;
    void Start()
    {
       
    }
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();

        if (counter == 0)
        {
            anim.Play("Nothing");
        }
        

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Room");

        roomTrans = new Transform[gameObjects.Length];

        for (int i = 0; i < gameObjects.Length; i++)
        {
            roomTrans[i] = gameObjects[i].transform;
            range = Vector2.Distance(transform.position, roomTrans[i].position);


            if (range > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, roomTrans[i].position, speed * Time.deltaTime);
            }
        }

        Debug.Log($"{roomTrans.Length.ToString()} found.");


        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (counter == 3)
        {
            anim.Play("Sleep");
            StartCoroutine("Sleeping");
           
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            counter++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Room")
        {
            Instantiate(Blood, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Tree")
        {
            Instantiate(Blood, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Rock")
        {
            Instantiate(Blood, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Sleeping()
    {
        //rb.isKinematic = false;
        Destroy(rb);
        yield return new WaitForSeconds(5);
        this.gameObject.AddComponent<Rigidbody2D>();
        
        //rb.isKinematic = true;
        counter = 0;
        anim.Play("Stand");
    }
}
