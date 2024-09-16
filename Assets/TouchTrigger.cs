using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    public float jumpForce;
    public int jumpCount;
    int isGrounded;

    Touch tap;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        jumpCount = jumpCount - 1;
    }

    // Update is called once per frame
    void Update()
    {
        TapReader();
    }

    void TapReader() {
        if (Input.touchCount > 0) {
            tap = Input.GetTouch(0);

            if (tap.phase == TouchPhase.Began && isGrounded < jumpCount) {
                Debug.Log("Tap");
                isGrounded++;

                rb.velocity += jumpForce * Vector3.up;

            }
            else if (tap.phase == TouchPhase.Began && isGrounded >= jumpCount) {
                Debug.Log("No more jump");
            }
        }
    }

    void OnCollisionStay() {
        isGrounded = 0;
        //Debug.Log("grounded"); <- working
    }
}
