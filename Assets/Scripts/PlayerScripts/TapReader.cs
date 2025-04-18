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
    public int count;
    public Rigidbody rb;
    public GameObject player;
  
    public bool touching;
    private bool touchconnected = true;

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


    public Animator playerAnimator;
    public void Tap() {

       
        if (Input.touchCount > 0) {
            
            tap = Input.GetTouch(0);

            if (touchconnected)
            {

                if (touching && touchTime >= 0.1f && delayedJumpDebounce == false && player.GetComponent<HealthManager>().dashing != true)
                {
                    delayedJumpDebounce = true;
                    Jump();
                }
                if (tap.phase == TouchPhase.Ended && touchTime < 0.1f && player.GetComponent<HealthManager>().dashing != true)
                {
                    Jump();
                }
                if (tap.phase == TouchPhase.Moved)
                {
                    lastTouch = tap.position;
                    if ( (Mathf.Abs(lastTouch.x - firstTouch.x) > dragDistance || Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance) && player.GetComponent<HealthManager>().dashing == false) {
                    Movement(); // function that runs if move is strong enough
                    }
                }


                if (tap.phase == TouchPhase.Began)
                {
                    touching = true;
                    touchTime = 0f;
                    firstTouch = tap.position;
                }


            }

            if (tap.phase == TouchPhase.Ended)
            {
                touchconnected = true;
                delayedJumpDebounce = false;
                touching = false;
            }


        }

        DashCheck();

    }

    public void Jump()
    {
            if (isGrounded < count)
            {
                    isGrounded++;
                    rb.velocity = force * Vector3.up;
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(skateJump, 1.0f);
                    playerAnimator.SetTrigger("isJumping");
            }
    }

    public void Movement() {
            touchconnected = false;
            player.GetComponent<HealthManager>().dashing = true;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(dashSound, 1.0f);
            playerAnimator.SetTrigger("isDashing");
    }

    void DashCheck() {
        if (player.GetComponent<HealthManager>().dashing == true)
        {

            rb.velocity = dash * Vector3.right;
            
            dashTimer += Time.deltaTime;
            if (dashTimer > dashLength) //dash length in seconds
            {
                player.GetComponent<HealthManager>().dashing = false;
                dashTimer = 0;
            }

        }
    }
}
