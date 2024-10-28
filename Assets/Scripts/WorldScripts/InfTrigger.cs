using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfTrigger : MonoBehaviour
{

    public GameObject[] genChunks;
    public float chunkWidth;

    Vector3 genPosition;


    void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {
            /* old from reg player usage
            genPosition = collider.gameObject.transform.position;
            genPosition = new Vector3(genPosition.x * 2, genPosition.y, genPosition.z);*/
            Instantiate(genChunks[Random.Range(0, genChunks.Length)], genPosition, Quaternion.identity);
        }
    }
}
