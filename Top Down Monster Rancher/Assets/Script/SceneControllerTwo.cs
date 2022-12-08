using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneControllerTwo : MonoBehaviour
{
    public int limit;

    public TextMeshProUGUI limitText;

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
        if (collision.gameObject.name == "Player")
        {
            if (limit <= 7000)
            {
                SceneManager.LoadScene("Second Level");
            }
            else
            {
                limitText.gameObject.SetActive(true);
                //limitText.text.enable = true;
            }
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
           limitText.gameObject.SetActive(false);
        }
    }
}