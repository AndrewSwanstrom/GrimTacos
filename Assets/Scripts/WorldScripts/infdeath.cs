using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infdeath : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(player.transform.position.x, this.gameObject.transform.position.y, player.transform.position.z);
    }
}
