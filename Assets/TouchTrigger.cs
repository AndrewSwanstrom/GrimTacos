using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    public float jumpForce;
    public float dashForce;
    public int jumpCount;
    public float screenPercent;

    int isGrounded;
    float dragDistance;
    Vector3 firstTouch;
    Vector3 lastTouch;

    Touch tap;
    Rigidbody rb;
    Transform obj;

    void Start() {
        rb = GetComponent<Rigidbody>();
        jumpCount = jumpCount - 1;
        dragDistance = Screen.height * screenPercent/100;
    }

    // Update is called once per frame
    void Update()
    {
        TapReader();
    }

    void OnCollisionStay(Collision collider) {
        if (collider.gameObject.tag == "Ground") {
        isGrounded = 0;
        }
        else if (collider.gameObject.tag == "Obstacle") {
            obj = GetComponent<Transform>();
            obj.position = Vector3.zero;
        }
    }

    void TapReader() {
        if (Input.touchCount > 0) {
            tap = Input.GetTouch(0);

            if (tap.phase == TouchPhase.Began && isGrounded < jumpCount) {
                Debug.Log("Tap");
                isGrounded++;
                firstTouch = tap.position;
                lastTouch = tap.position;

                rb.velocity += jumpForce * Vector3.up;

            }
            else if (tap.phase == TouchPhase.Began && isGrounded >= jumpCount) {
                Debug.Log("No more jump");
            }
            else if (tap.phase == TouchPhase.Moved) {
                lastTouch = tap.position;
                Movement();
            }
        }
    }

    void Movement() {
        if (Mathf.Abs(lastTouch.x - firstTouch.x) > dragDistance || Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance) {
                rb.velocity += dashForce * Vector3.right;
        }
    }


}
