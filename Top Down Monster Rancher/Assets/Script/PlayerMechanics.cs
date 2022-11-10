using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{

    public GameObject Room;
    public GameObject Bullet;
    public int mush = 0;
    public int howMany = 0;
    public int money = 0;
    public GameController GameManager;

   
    // Start is called before the first frame update
    void Start()
    {
       GameManager.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, this.transform.position, Quaternion.identity);
        }
        //MONEY NO WORK???
        money = howMany * 100;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GameManager")
        {
            //GameManager.DecreaseDebt(money);
           // money = 0;
        }


        if (collision.gameObject.tag == "Room")
        {
            mush += 1;
            Destroy(collision.gameObject);
         
        }

        if (collision.gameObject.name == "right wall" && mush >= 1)
        {
            mush--;
            howMany++;
            Instantiate(Room, collision.gameObject.transform.position, Quaternion.identity);
        }
    }
}
