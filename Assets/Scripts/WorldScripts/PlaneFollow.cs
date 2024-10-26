using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFollow : MonoBehaviour
{
    public GameObject target;
    Vector3 transform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform = target.transform.position + new Vector3(0, -5, 0);
    }
}
