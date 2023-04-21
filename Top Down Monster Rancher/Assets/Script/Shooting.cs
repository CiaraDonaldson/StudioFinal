using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    public int counter = 0;
    public int milk = 100;
    public bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
      
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
                counter += 10;
                canFire = true;
                timer = 0;
            }
        }

        if (counter == 50) 
        {
            milk -= counter;
        }
        else
            if(milk == 0)
            {
                stop = true;
            }

        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetMouseButtonDown(0) && canFire && scene.name != "Toriel")
            {
                canFire = false;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }
        
    }

    public void addMilk()
    {
        milk = 100;
        stop = false;
    }
}
