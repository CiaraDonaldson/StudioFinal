using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCanvasAnimator : MonoBehaviour
{
    public Image imageCanvas;


    public SpriteRenderer Milk;

    public Animator Milk2;


    void Start()
    {
        Milk = GameObject.Find("milkImage").GetComponent<SpriteRenderer>();
        Milk2 = GameObject.Find("milkImage").GetComponent<Animator>();

        imageCanvas = GetComponent<Image>();


        Milk.enabled = false;
        Milk2 = gameObject.GetComponent<Animator>();



    }

    void Update()
    {
            imageCanvas.sprite = Milk.sprite;
    }
}
