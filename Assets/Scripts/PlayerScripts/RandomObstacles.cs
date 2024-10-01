using System.Collections;
using System.Collections.Generic;
using UnityEngine.Splines;
using UnityEngine;

public class RandomObstacles : MonoBehaviour
{

    //private Vector3 v;
    private Vector3 p0;
    private Vector3 p1;

    public int obstaclesToSpawn = 1; //just gonna leave it at 1 per obstacle spawner

    public GameObject[] obstacleArray;

    // Start is called before the first frame update
    void Start()
    {

        //for (int i = 0; i < obstaclesToSpawn; i++)
       // {

        //set up the two points where we spawn random obstacles
        p0 = gameObject.transform.position + gameObject.transform.right * (gameObject.transform.localScale.x/2);
        p1 = gameObject.transform.position + gameObject.transform.right * (-gameObject.transform.localScale.x/2);

        //pick a random position within a straight line between the two points
        Vector3 v = p1 - p0; 
        Vector3 target_position = p0 + Random.value * v;

        //instantiate a random obstacle from array
        Instantiate(obstacleArray[Random.Range(0, obstacleArray.Length)], target_position, Quaternion.identity);

        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
