using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIn : MonoBehaviour
{
    public GameObject player;
    private Vector3 beHere;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector2(0f, 0f);;
        player = GameObject.Find("Player");
        beHere = player.transform.position;
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
