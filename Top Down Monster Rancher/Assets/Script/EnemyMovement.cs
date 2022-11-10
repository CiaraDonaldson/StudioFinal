using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    private float minDistance = 1f;
    private float range;
    public int counter = 0;

    void Start()
    {
        //GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Room")
    }
    void Update()
    {
        FindClosestEnemy();
        
       /* range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
           transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }*/

        if (counter == 3)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
    void onTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hurt");
            counter+=1;

        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "room")
        {
            Destroy(collision.gameObject);
        }
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Room");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
