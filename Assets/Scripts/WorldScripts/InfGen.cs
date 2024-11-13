using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfGen : MonoBehaviour
{

    public GameObject[] genChunks;
    public int widthMin, widthMax;
    public int lengthMin, lengthMax;

    float chunkWidth;
    float chunkLength;

    Vector3 genPosition;

    List<GameObject> chunkList = new List<GameObject>();


    void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.CompareTag("Killzone")) {
            foreach (GameObject chunk in chunkList) {
                Destroy(chunk);
            }
            chunkList.Clear();
        }
        if (collider.gameObject.CompareTag("Trigger")) {
            chunkWidth = Random.Range(widthMin, widthMax);
            chunkLength = Random.Range(lengthMin, lengthMax);

            genPosition = collider.transform.position + Vector3.right * chunkWidth + Vector3.up * chunkLength;

            GameObject chunkItem = Instantiate(genChunks[Random.Range(0, genChunks.Length)], genPosition, Quaternion.identity);
            chunkList.Add(chunkItem);

            //Debug.Log(chunkList.Count);
        }
        if (chunkList.Count > 5) {
            Destroy(chunkList[0]);
            chunkList.RemoveAt(0);

            //Debug.Log("chunk removed");
        }
    }
}
