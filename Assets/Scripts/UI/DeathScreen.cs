using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    TouchTrigger player;

    void Start() {
        player = GameObject.Find("Player").GetComponent<TouchTrigger>();
    }

    public void Retry() {
        Time.timeScale = 1;
        //player.maxSpeed = 10;
        deathScreen.SetActive(false);
    }

    public void Quit() {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }

}
