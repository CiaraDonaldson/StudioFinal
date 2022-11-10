using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    
    public int debt = 100;
    public int saved = 0;

    public GameObject go; 
    public GameObject Player;
    public PlayerMechanics PlayerScript;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(Player, new Vector3(0, 0, -1), Quaternion.identity);
    }
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

    /*public void DecreaseDebt(int money)
    {
        debt -= money;
        Debug.Log(debt);
    
    }*/
    public void Starting()
    {
        SceneManager.LoadScene("Your Farm");
    }
}
