using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfGenDeath : MonoBehaviour
{
    InfGen infGen;
    HealthManager healthManager;
    InfGenScore score;
    infdeath death;
    // Start is called before the first frame update
    void Start()
    {
        infGen = this.gameObject.GetComponent<InfGen>();
        healthManager = this.gameObject.GetComponent<HealthManager>();
        score = this.gameObject.GetComponent<InfGenScore>();
        death = GameObject.Find("death plane").GetComponent<infdeath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.genDeath == true) {
            score.SaveScore();
            death.Death();
            
            foreach (GameObject g in infGen.chunkList) {
                Destroy(g);
            }
            infGen.chunkList.Clear();
            healthManager.genDeath = false;
        }
    }
}
