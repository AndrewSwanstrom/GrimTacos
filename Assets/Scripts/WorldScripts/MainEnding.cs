using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnding : MonoBehaviour
{

    public GameObject endScreen;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<NewInput>().enabled = false;
            endScreen.SetActive(true);
        }
    }

}
