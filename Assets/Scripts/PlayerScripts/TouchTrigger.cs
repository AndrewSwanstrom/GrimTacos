using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    public float jumpForce;
    public float dashForce;
    public int jumpCount;
    public float screenPercent;

    public float speed = 10.0f;

    private GameObject checkpoint;

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
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x + 0.1f,0,speed) , rb.velocity.y, rb.velocity.z); // move right
        //Vector3.ClampMagnitude(rb.velocity + Vector3.right, 10);
    }

    void OnCollisionStay(Collision collider) {
        if (collider.gameObject.tag == "Ground") {
        isGrounded = 0;
        }
        else if (collider.gameObject.tag == "Obstacle") {
            obj = GetComponent<Transform>();

            checkpoint = gameObject.GetComponent<ActivateCheckpoint>().currentCheckpoint;
            if (checkpoint != null)
            {
                obj.position = checkpoint.transform.position;
            } 
            else
            {
                obj.position = Vector3.zero;
            }
            
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
        if (Input.GetMouseButtonDown(0))
        {
            
            isGrounded++;
            //Debug.Log(isGrounded);
            //firstTouch = tap.position;
            //lastTouch = tap.position;

            rb.velocity += jumpForce * Vector3.up;
        }
    }

    void Movement() {
        if (Mathf.Abs(lastTouch.x - firstTouch.x) > dragDistance || Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance) {
                rb.velocity += dashForce * Vector3.right;
        }
    }


}
