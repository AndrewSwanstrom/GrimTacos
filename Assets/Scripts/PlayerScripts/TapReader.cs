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

    public Animator playerAnimator;

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
                playerAnimator.SetBool("isJumping", true);
            }
            else if (tap.phase == TouchPhase.Began && isGrounded >= count) {
                //Debug.Log("No more jump");
                playerAnimator.SetBool("isJumping", false);
            }
            else if (tap.phase == TouchPhase.Moved) {
                lastTouch = tap.position;
                Movement();
            }


            if (tap.phase == TouchPhase.Began)
            {

                touching = true;
                touchTime = 1.0f;
            }

            if (tap.phase == TouchPhase.Ended)
            {
                //Debug.Log(touching);
                touching = false;
                touchTime = 2.0f;
            }

        }
    }

    void Movement() {
        if (Mathf.Abs(lastTouch.x - firstTouch.x) > dragDistance || Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance) {
                rb.velocity += dash * Vector3.right;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(skateJump, 1.0f);
            Debug.Log("Swipe");
        }
    }
}
