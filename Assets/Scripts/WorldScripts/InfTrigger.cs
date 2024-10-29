using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfTrigger : MonoBehaviour
{

    public GameObject[] genChunks;
    public float chunkWidth = 20f;

    Vector3 genPosition;


    void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {

            genPosition = collider.gameObject.transform.position;
            genPosition = new Vector3(genPosition.x + chunkWidth, genPosition.y, genPosition.z);

            Instantiate(genChunks[Random.Range(0, genChunks.Length)], genPosition, Quaternion.identity);
        }
    }
}
