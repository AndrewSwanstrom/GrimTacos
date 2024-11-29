using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingOptions : MonoBehaviour
{
    public void Retry() {
        SceneManager.LoadScene("Playable Level", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void Back() {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
