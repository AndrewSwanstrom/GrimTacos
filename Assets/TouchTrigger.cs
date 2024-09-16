using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    public float jumpForce;
    bool isGrounded;

    Touch tap;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TapReader();
    }

    void TapReader() {
        if (Input.touchCount > 0) {
            tap = Input.GetTouch(0);
            int tapCount = 0;

            if (tap.phase == TouchPhase.Began && tapCount < 2) {
                Debug.Log("Tap");
                isGrounded = false;
                tapCount++;

                rb.velocity += jumpForce * Vector3.up;

            }
            else if (tap.phase == TouchPhase.Began && tapCount >= 2) {
                Debug.Log("No more jump");
            }
        }
    }

    void OnCollisionStay() {
        isGrounded = true;
        //Debug.Log("grounded"); <- working
    }
}
