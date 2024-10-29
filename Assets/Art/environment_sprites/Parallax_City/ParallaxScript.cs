using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float length, startposX, startposY;
    public GameObject cam;
    public float parallaxEffect;
    public float offset;
    public GameObject player;

    void Start()
    {
        startposX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startposY = transform.position.y;
        
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distX = (cam.transform.position.x * parallaxEffect);
        float distY = (cam.transform.position.y * offset);

        transform.position = new Vector3(startposX + distX, player.transform.position.y + distY, transform.position.z);

        if (temp > startposX + length)
        {
            startposX += length;
        }
        else if (temp < startposX - length)
        {
            startposX -= length;
        }
    }
}
