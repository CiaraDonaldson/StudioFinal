using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public TextMeshProUGUI moneyCounter;
    public int moneyy;

 
    void Awake()
    {

        moneyCounter = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        moneyCounter.text = moneyy.ToString();
    }

    private IEnumerator Pulse()
    {
        for (float i = 3.06f; i <= 4f; i += 0.05f)
        {
            moneyCounter.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }

        moneyCounter.rectTransform.localScale = new Vector3(4f, 4f, 4f);
        moneyy = PlayerMechanics.instance.money;

        for (float i = 4f; i >= 3.06f; i -= 0.05f)
        {
            moneyCounter.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        moneyCounter.rectTransform.localScale = new Vector3(3.06f, 3.06f, 3.06f);
    }

    public void RunCo()
    {
        StartCoroutine(Pulse());
    }
}
