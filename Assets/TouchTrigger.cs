using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    TapReader tapScript;
    public float jumpForce;
    public float dashForce;
    public int jumpCount;
    public float screenPercent;

    public float speed = 10.0f;

    Rigidbody rb;
    Transform obj;

    void Start() {
        tapScript = new TapReader();
        rb = GetComponent<Rigidbody>(); tapScript.rb = rb;
        jumpCount = jumpCount - 1;

        tapScript.dash = dashForce;
        tapScript.force = jumpForce;
        tapScript.count = jumpCount;
        tapScript.dragDistance = Screen.height * screenPercent/100;
    }

    // Update is called once per frame
    void Update()
    {
        tapScript.Tap();

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x + 0.1f,0,speed) , rb.velocity.y, rb.velocity.z); // move right
        //Vector3.ClampMagnitude(rb.velocity + Vector3.right, 10);
    }

    void OnCollisionStay(Collision collider) {
        if (collider.gameObject.tag == "Ground") {
        tapScript.isGrounded = 0;
        }
        else if (collider.gameObject.tag == "Obstacle") {
            obj = GetComponent<Transform>();
            obj.position = Vector3.zero;
        }
    }


}
