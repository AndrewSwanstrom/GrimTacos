using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject title, level, options;

    public void StartGame() {
        title.SetActive(false);
        level.SetActive(true);
    }

    public void MainLevel() {
        SceneManager.LoadScene("Playable Level", LoadSceneMode.Single);
    }

    public void InfLevel() {
        SceneManager.LoadScene("InfGen", LoadSceneMode.Single);
    }

    public void Options() {
        title.SetActive(false);
        options.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }

    public void BackToStart() {
        if (level.activeInHierarchy == true) {
            level.SetActive(false);
        }
        if (options.activeInHierarchy == true) {
            options.SetActive(false);
        }
        title.SetActive(true);
    }
}
