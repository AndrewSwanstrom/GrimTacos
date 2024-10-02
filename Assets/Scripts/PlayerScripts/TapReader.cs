using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapReader
{
    public int isGrounded;
    public float dragDistance;
    public float force;
    public float dash;
    public int count;
    public Rigidbody rb;


    Touch tap;
    Vector3 firstTouch;
    Vector3 lastTouch;

    public void Tap() {
        if (Input.touchCount > 0) {
            tap = Input.GetTouch(0);

            if (tap.phase == TouchPhase.Began && isGrounded < count) {
                //Debug.Log("Tap");
                isGrounded++;
                firstTouch = tap.position;
                lastTouch = tap.position;

                rb.velocity += force * Vector3.up;

            }
            else if (tap.phase == TouchPhase.Began && isGrounded >= count) {
                //Debug.Log("No more jump");
            }
            else if (tap.phase == TouchPhase.Moved) {
                lastTouch = tap.position;
                Movement();
            }
        }
    }

    void Movement() {
        if (Mathf.Abs(lastTouch.x - firstTouch.x) > dragDistance || Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance) {
                rb.velocity += dash * Vector3.right;
                Debug.Log("Swipe");
        }
    }
}
