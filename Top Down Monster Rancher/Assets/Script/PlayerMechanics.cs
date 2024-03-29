using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerMechanics : MonoBehaviour
{
    public static PlayerMechanics instance;

    public GameObject Room;
    public GameObject Tree;
    public GameObject Rock;
    public GameObject Room2;
    public GameObject Tree2;
    public GameObject Rock2;
    public GameObject Bullet;
    public int mush = 0;
    public int root = 0;
    public int pebble = 0;
    public int howMany = 0;
    public int money = 0;
    public int holding = 0;
    public Rigidbody2D rb;

    public HoldCounter HoldScript;
    public MoneyCounter MoneyScript;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = new Vector3(0,0,-1);

        
    }

    // Update is called once per frame
    void Update()
    {
        HoldScript = FindObjectOfType<HoldCounter>();
        MoneyScript = FindObjectOfType<MoneyCounter>();

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Toriel")
        {
            if (rb)
            {
                Destroy(rb);
            }
            else if(Input.GetKey("Space") & Input.GetKey("x"))
                {
                SceneManager.LoadScene("Your Farm");
                }
        }
        else if (scene.name == "Your Farm" & this.gameObject.GetComponent<Rigidbody2D>() == null)
        {
            this.gameObject.AddComponent<Rigidbody2D>();
        }
        if (scene.name == "Ending")
        {
            Destroy(this.gameObject);
        }

            rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }


        
        holding = mush + root + pebble;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Room")
        {
            mush += 1;
            Destroy(collision.gameObject);
            HoldScript.RunCo();
        }
        if (collision.gameObject.tag == "Room2")
        {
            mush += 1;
            Destroy(collision.gameObject);
            HoldScript.RunCo();
        }

        if (collision.gameObject.name == "right wall" && mush >= 1)
        {
            mush--;
            howMany++;
            money = howMany * 25;
            Instantiate(Room2, collision.gameObject.transform.position, Quaternion.identity);
            HoldScript.RunCo();
            MoneyScript.RunCo();
        }
        if (collision.gameObject.tag == "Tree")
        {
            root += 1;
            Destroy(collision.gameObject);
            HoldScript.RunCo();
        }
        if (collision.gameObject.tag == "Tree2")
        {
            root += 1;
            Destroy(collision.gameObject);
            HoldScript.RunCo();
        }

        if (collision.gameObject.name == "right wall" && root >= 1)
        {
            root--;
            howMany += 2;
            money = howMany * 25;
            Instantiate(Tree2, collision.gameObject.transform.position, Quaternion.identity);
            HoldScript.RunCo();
            MoneyScript.RunCo();
        }
        if (collision.gameObject.tag == "Rock")
        {
            pebble += 1;
            Destroy(collision.gameObject);
            HoldScript.RunCo();
        }
        if (collision.gameObject.tag == "Rock2")
        {
            pebble += 1;
            Destroy(collision.gameObject);
            HoldScript.RunCo();
        }

        if (collision.gameObject.name == "right wall" && pebble >= 1)
        {
            pebble--;
            howMany += 3;
            money = howMany * 25;
            Instantiate(Rock2, collision.gameObject.transform.position, Quaternion.identity);
            HoldScript.RunCo();
            MoneyScript.RunCo();
        }
        
            
            
        
    }
}
