using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene1 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
