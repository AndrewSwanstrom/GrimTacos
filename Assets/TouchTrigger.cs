using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    public float jumpForce;

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

            if (tap.phase == TouchPhase.Began) {
                Debug.Log("Tap");

                rb.velocity += jumpForce * Vector3.up;

            }
        }
    }
}
