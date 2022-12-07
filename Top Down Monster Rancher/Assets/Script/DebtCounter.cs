using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebtCounter : MonoBehaviour
{
    public TextMeshProUGUI debtCounter;
    public int debt = 10000;

 
    void Awake()
    {
        
        debtCounter = GetComponent<TextMeshProUGUI>();
        debt = GameController.instance.debtmon;
    }


    void Update()
    {
        debtCounter.text = debt.ToString();
    }

    private IEnumerator Pulse()
    {
        for (float i = 3.06f; i <= 4f; i += 0.05f)
        {
            debtCounter.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }

        debtCounter.rectTransform.localScale = new Vector3(4f, 4f, 4f);
        debt -= GameController.instance.saved;

        for (float i = 4f; i >= 3.06f; i -= 0.05f)
        {
            debtCounter.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        debtCounter.rectTransform.localScale = new Vector3(3.06f, 3.06f, 3.06f);
    }

    public void RunCo()
    {
        StartCoroutine(Pulse());
    }
}
