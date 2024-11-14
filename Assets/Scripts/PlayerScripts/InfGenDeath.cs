using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfGenDeath : MonoBehaviour
{
    InfGen infGen;
    HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        infGen = this.gameObject.GetComponent<InfGen>();
        healthManager = this.gameObject.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.genDeath == true) {
            foreach (GameObject g in infGen.chunkList) {
                Destroy(g);
            }
            infGen.chunkList.Clear();
            healthManager.genDeath = false;
        }
    }
}
