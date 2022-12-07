using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoldCounter : MonoBehaviour
{
    public TextMeshProUGUI holdCounter;
    public int holdd;

 
    void Awake()
    {

        holdCounter = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        holdCounter.text = holdd.ToString();
    }

    private IEnumerator Pulse()
    {
        for (float i = 3.06f; i <= 4f; i += 0.05f)
        {
            holdCounter.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }

        holdCounter.rectTransform.localScale = new Vector3(4f, 4f, 4f);
        holdd = PlayerMechanics.instance.holding;

        for (float i = 4f; i >= 3.06f; i -= 0.05f)
        {
            holdCounter.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        holdCounter.rectTransform.localScale = new Vector3(3.06f, 3.06f, 3.06f);
    }

    public void RunCo()
    {
        StartCoroutine(Pulse());
    }
}
