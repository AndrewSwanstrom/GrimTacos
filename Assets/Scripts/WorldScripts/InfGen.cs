using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfGen : MonoBehaviour
{

    public GameObject[] genChunks;
    float chunkWidth;
    float chunkLength;

    Vector3 genPosition;

    List<GameObject> chunkList = new List<GameObject>();


    void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.CompareTag("Trigger")) {
            chunkWidth = Random.Range(25, 30);
            chunkLength = Random.Range(-2, 1);

            genPosition = collider.transform.position + Vector3.right * chunkWidth + Vector3.up * chunkLength;

            GameObject chunkItem = Instantiate(genChunks[Random.Range(0, genChunks.Length)], genPosition, Quaternion.identity);
            chunkList.Add(chunkItem);

            Debug.Log(chunkList.Count);
        }
        if (chunkList.Count > 5) {
            Destroy(chunkList[0]);
            chunkList.RemoveAt(0);

            Debug.Log("chunk removed");
        }
    }
}
