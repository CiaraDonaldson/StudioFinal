using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int debtmon = 100;
    public int saved = 0;

    public GameObject go;

    public PlayerMechanics PlayerScript;
    public DebtCounter DebtScript;
    public MoneyCounter MoneyScript;
    // Start is called before the first frame update

    void Start()
    {
        instance = this;
        PlayerScript = FindObjectOfType<PlayerMechanics>();
        go = GameObject.Find("Player");
        PlayerScript = (PlayerMechanics)go.GetComponent(typeof(PlayerMechanics));
        DebtScript = FindObjectOfType<DebtCounter>();
        MoneyScript = FindObjectOfType<MoneyCounter>();
        Debug.Log(debtmon);

    }


    void Update()
    {


        /*if (debt <= 0)
        {
           SceneManager.LoadScene("Your Farm");
            debt = 100;
        }*/
    }
    void FixedUpdate()
    {

        saved = PlayerMechanics.instance.money;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            debtmon -= saved;
            Debug.Log(debtmon);
            StartCoroutine(moneySub());
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            saved = 0;
            Debug.Log(saved);
        }
    }

    public void Starting()
    {
        SceneManager.LoadScene("Toriel");

    }

    private IEnumerator moneySub()
    {
        DebtScript.RunCo();
        yield return new WaitForSeconds(1f);
        PlayerMechanics.instance.money = 0;
        MoneyScript.RunCo();
    }
}
