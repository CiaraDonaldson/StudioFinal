using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    
    public int debt = 100;
    public int saved = 0;

    public GameObject go;
    private bool done = false;
    public PlayerMechanics PlayerScript;
    // Start is called before the first frame update

    void Start()
    {
       DontDestroyOnLoad(this.gameObject);
        PlayerScript = FindObjectOfType<PlayerMechanics>();
        go = GameObject.Find("Player");
        PlayerScript = (PlayerMechanics)go.GetComponent(typeof(PlayerMechanics));

        Debug.Log(debt);

    }

 
    void Update()
    {


        if (debt <= 0)
        {
           SceneManager.LoadScene("Your Farm");
            debt = 100;
        }
    }
    void FixedUpdate()
    {
        saved = PlayerScript.money;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            debt -= saved;
            Debug.Log(debt);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            saved = 0;
            Debug.Log(saved);
            done = true;
        }
    }

    /*public void DecreaseDebt(int money)
    {
        debt -= money;
        Debug.Log(debt);
    
    }*/
    public void Starting()
    {
        SceneManager.LoadScene("Your Farm");

       // if (!rb) { rb = gameObject.AddComponent<Rigidbody2D>(); }
    }
}
