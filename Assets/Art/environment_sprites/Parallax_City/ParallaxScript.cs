using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float length, height, startposX, startposY;
    public GameObject cam;
    public float parallaxEffect;
    public float offset;
    public GameObject player;
    public bool bottom;

    void Start()
    {
        startposX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        startposY = transform.position.y;

           
        
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distX = (cam.transform.position.x * parallaxEffect);
        float distY = (cam.transform.position.y * offset);

        if (bottom == true)
        {
            distY = ((cam.transform.position.y + 18f) * offset);
        }

        transform.position = new Vector3(startposX + distX, player.transform.position.y + distY, transform.position.z);

        if (temp > startposX + length)
        {
            startposX += length;
        }
        else if (temp < startposX - length)
        {
            startposX -= length;
        }

        if (temp > startposY + height)
        {
            startposY += height;
        }
        else if (temp < startposY - height)
        {
            startposY -= height;
        }

        
    }
}
