using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerTwo : MonoBehaviour
{
    public int limit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {       
        limit = GameController.instance.debtmon;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" &&  limit <= 7000)
        {
            SceneManager.LoadScene("Second Level");
        }
    }
}