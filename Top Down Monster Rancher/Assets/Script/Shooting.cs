using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    public int milkcount;
    public bool stop = false;

    public GameObject Milk;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Milk = GameObject.FindGameObjectWithTag("milk");
      
    }

    // Update is called once per frame
    void Update()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rot2 = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot2);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {                
                canFire = true;
                timer = 0;
            }
        }

  
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetMouseButtonDown(0) && canFire && scene.name != "Toriel")
            {
            //canFire = false;
            milkcount--;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }

        if (milkcount == 35)
        {
            Debug.Log("35");
            Milk.GetComponent<Animator>().Play("full to half");
            // milk -= counter;
        }
        else
            if (milkcount == 10)
        {
            Debug.Log("10");
            Milk.GetComponent<Animator>().Play("half to low");
            //milk -= counter;
        }
        else
            if (milkcount <= 0)
        {
            Milk.GetComponent<Animator>().Play("low to empty");
            Debug.Log("stop");
            canFire = false;
        }

    }

    public void addMilk()
    {
        Milk.GetComponent<Animator>().Play("empty to full");
        milkcount = 50;
        canFire = true;
    }
}
