using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infdeath : MonoBehaviour
{
    public GameObject player;
    public GameObject deathScreen;
    TouchTrigger playerSpeed;

    void Start() {
        playerSpeed = player.GetComponent<TouchTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(player.transform.position.x, this.gameObject.transform.position.y, player.transform.position.z);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Time.timeScale = 0;
            //playerSpeed.maxSpeed = 0;
            deathScreen.SetActive(true);
        }
    }
}
