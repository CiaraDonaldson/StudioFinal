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
    public Transform[] monstTrans;
    public GameObject Blood;
    public AudioSource audio;
    public AudioSource audio2;
    void Start()
    {
        
    }
    void Update()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        if (counter == 0)
        {
            anim.Play("Nothing");
        }

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "First Level" || scene.name == "Your Farm")
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Room");

            monstTrans = new Transform[gameObjects.Length];

            for (int i = 0; i < gameObjects.Length; i++)
            {
                monstTrans[i] = gameObjects[i].transform;
                range = Vector2.Distance(transform.position, monstTrans[i].position);


                if (range > minDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, monstTrans[i].position, speed * Time.deltaTime);
                }
            }

            Debug.Log($"{monstTrans.Length.ToString()} found.");
        }
        else if (scene.name == "Second Level")
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Tree");

            monstTrans = new Transform[gameObjects.Length];

            for (int i = 0; i < gameObjects.Length; i++)
            {
                monstTrans[i] = gameObjects[i].transform;
                range = Vector2.Distance(transform.position, monstTrans[i].position);


                if (range > minDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, monstTrans[i].position, speed * Time.deltaTime);
                }
            }

        }
        else 
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Rock");

            monstTrans = new Transform[gameObjects.Length];

            for (int i = 0; i < gameObjects.Length; i++)
            {
                monstTrans[i] = gameObjects[i].transform;
                range = Vector2.Distance(transform.position, monstTrans[i].position);


                if (range > minDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, monstTrans[i].position, speed * Time.deltaTime);
                }
            }
        }

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
            audio2.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Room")
        {
            Instantiate(Blood, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            audio.Play();
        }

        if (collision.gameObject.tag == "Tree")
        {
            Instantiate(Blood, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            audio.Play();
        }

        if (collision.gameObject.tag == "Rock")
        {
            Instantiate(Blood, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            audio.Play();
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
