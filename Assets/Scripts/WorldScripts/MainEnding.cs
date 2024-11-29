using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnding : MonoBehaviour
{

    public GameObject endScreen;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Time.timeScale = 0;
            endScreen.SetActive(true);
        }
    }

}
