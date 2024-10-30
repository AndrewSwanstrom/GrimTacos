using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapReader
{
    public int isGrounded;
    public float dragDistance;
    public float force;
    public float dash;
    public bool dashing = false;
    public int count;
    public Rigidbody rb;
    public GameObject player;
   


    public bool touching;
    public float touchTime;

    AudioSource audioSource;
    public AudioClip dashSound;
    public AudioClip skateRoll;
    public AudioClip skateJump;
    public AudioClip skateLand;

    Touch tap;
    Vector3 firstTouch;
    Vector3 lastTouch;

    //next: get time tap is held, if held longer than 0.3 seconds, jump. if it moves within those 0.3 seconds, dont jump. if let go within those 0.3 seconds (and doesnt travel far enough) then jump.


    public void Tap() {
        if (Input.touchCount > 0) {
            tap = Input.GetTouch(0);

            if (tap.phase == TouchPhase.Began && isGrounded < count) {
                isGrounded++;
                firstTouch = tap.position;
                lastTouch = tap.position;
                
                rb.velocity += force * Vector3.up;

                Camera.main.GetComponent<AudioSource>().PlayOneShot(skateJump, 1.0f);
            }
            else if (tap.phase == TouchPhase.Began && isGrounded >= count) {
                //Debug.Log("No more jump");
            }
            else if (tap.phase == TouchPhase.Moved) {
                lastTouch = tap.position;
                Movement();
            }


            if (tap.phase == TouchPhase.Began)
            {
                
                //dashing = true;
                touching = true;
                touchTime = 1.0f;
            }

            if (tap.phase == TouchPhase.Ended)
            {
                //Debug.Log("ended");
                //dashing = false;
                touching = false;
                //dashing = false; //temp
                touchTime = 2.0f;
            }

        }
    }

    void Movement() {
        if (Mathf.Abs(lastTouch.x - firstTouch.x) > dragDistance || Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance) {
                rb.velocity += dash * Vector3.right;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(skateJump, 1.0f);
           //dashing = true;
            //Debug.Log("Swipe");
        }
        else
        {
           // dashing = false;
        }
    }
}
