using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerMechanics : MonoBehaviour
{

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

    public GameController GameManager;
    public Rigidbody2D rb;


    public TextMeshProUGUI Holdcount;
    public TextMeshProUGUI Moneycount;

    private GameObject can;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        can = GameObject.Find("Canvas");
        Holdcount = can.GetComponent<TextMeshProUGUI>();
        Moneycount = can.GetComponent<TextMeshProUGUI>();

        this.gameObject.transform.position = new Vector3(0,0,-1);
       GameManager.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Toriel")
        {
            if (rb)
            {
                Destroy(rb);
            }
        }
        else if (scene.name == "Your Farm" & this.gameObject.GetComponent<Rigidbody2D>() == null)
        {
            this.gameObject.AddComponent<Rigidbody2D>();
        }
               
            
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;


        money = howMany * 25;
        holding = mush + root + pebble;

        Moneycount.SetText(money.ToString());
        Holdcount.SetText(holding.ToString());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
       

        if (collision.gameObject.tag == "Room")
        {
            mush += 1;
            Destroy(collision.gameObject);
         
        }
        if (collision.gameObject.tag == "Room2")
        {
            mush += 1;
            Destroy(collision.gameObject);
         
        }

        if (collision.gameObject.name == "right wall" && mush >= 1)
        {
            mush--;
            howMany++;
            Instantiate(Room2, collision.gameObject.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Tree")
        {
            root += 1;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "Tree2")
        {
            root += 1;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.name == "right wall" && root >= 1)
        {
            root--;
            howMany+= 2;
            Instantiate(Tree2, collision.gameObject.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Rock")
        {
            pebble += 1;
            Destroy(collision.gameObject);
         
        }
        if (collision.gameObject.tag == "Rock2")
        {
            pebble += 1;
            Destroy(collision.gameObject);
         
        }

        if (collision.gameObject.name == "right wall" && pebble >= 1)
        {
            pebble--;
            howMany+=3;
            Instantiate(Rock2, collision.gameObject.transform.position, Quaternion.identity);
        }
    }
}
