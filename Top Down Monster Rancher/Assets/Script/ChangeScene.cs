using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Your Farm", LoadSceneMode.Additive);
    }
}
