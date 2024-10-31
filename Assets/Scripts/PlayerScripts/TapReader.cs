using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapReader
{
    public int isGrounded;
    public float dragDistance;
    public float force;
    public float dash;
    private float dashTimer;
    private float dashLength = 0.4f;
    //public bool dashing = false;
    public int count;
    public Rigidbody rb;
    public GameObject player;
  
    public bool touching;

    private bool delayedJumpDebounce = false;

    public float touchTime = 0;

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
            //Debug.Log(touching);
            tap = Input.GetTouch(0);


           // if (tap.phase == TouchPhase.Stationary && touching == false)
            //{
                //touching = true;
            //}

            if (tap.phase == TouchPhase.Stationary && touchTime > 0.03f && delayedJumpDebounce == false)
            {
                delayedJumpDebounce = true;
                //Debug.Log("jump (late)"); // would be ideal to disconnect this touch somehow, but isnt likely a real issue
                Jump();
            }
            if (tap.phase == TouchPhase.Ended && touchTime < 0.1f && player.GetComponent<HealthManager>().dashing == false)
            {
                //lastTouch = null;
                //Debug.Log("jump (early)");
                Jump();
            }
            if (tap.phase == TouchPhase.Moved)
            {
                lastTouch = tap.position;
                Movement(); // function that runs if move is strong enough
            }

            //if (tap.phase == TouchPhase.Began && isGrounded < count) {

            //}
            //else if (tap.phase == TouchPhase.Began && isGrounded >= count) {
                //Debug.Log("No more jump");
            //}
            //else if (tap.phase == TouchPhase.Moved) {
            //    lastTouch = tap.position;
            //    Movement();
            //}


            if (tap.phase == TouchPhase.Began)
            {             
                touching = true;
                touchTime = 0f;
                firstTouch = tap.position;
            }

            if (tap.phase == TouchPhase.Ended)
            {
                delayedJumpDebounce = false;
                touching = false;
                //player.GetComponent<HealthManager>().dashing = false; //temp spot
            }

        }

        if (player.GetComponent<HealthManager>().dashing == true)
        {

            touchTime = 0;
            rb.velocity += dash * Vector3.right;
            
            dashTimer += Time.deltaTime;
            if (dashTimer > dashLength) //dash length in seconds
            {
                player.GetComponent<HealthManager>().dashing = false;
                dashTimer = 0;
            }

        }

    }

    void Jump()
    {
        if (isGrounded < count) {
            isGrounded++;
            //firstTouch = tap.position;
            //lastTouch = tap.position;
            rb.velocity += force * Vector3.up;

            Camera.main.GetComponent<AudioSource>().PlayOneShot(skateJump, 1.0f);
        }
    }

    void Movement() {
        if ( (Mathf.Abs(lastTouch.x - firstTouch.x) > dragDistance || Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance) && player.GetComponent<HealthManager>().dashing == false) {
            player.GetComponent<HealthManager>().dashing = true;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(dashSound, 1.0f);
            //touchTime = 0;
            //rb.velocity += dash * Vector3.right;
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(skateJump, 1.0f);
        }
    }
}
