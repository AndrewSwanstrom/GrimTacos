using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapReader
{
    public int isGrounded;
    public float dragDistance;
    public float force;
    public float dash;
   // private bool dashing = false;
    private float dashTimer;
    private float dashLength = 0.4f;
    //public bool dashing = false;
    public int count;
    public Rigidbody rb;
    public GameObject player;
  
    public bool touching;

    private bool delayedJumpDebounce = false;

    //double jump bugfix variables:
    //private float jumpinitialtime;
    //private float jumpcooldowntimer;

    
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


            ////maybe add slight jump cooldown so player doesnt accidently double-tap jump?
            //if (tap.phase == TouchPhase.Stationary && touchTime > 0.03f && delayedJumpDebounce == false)
            //{
            //    delayedJumpDebounce = true;
            //    Debug.Log("jump (late)"); // would be ideal to disconnect this touch somehow, but isnt likely a real issue
            //    Jump();
            //}

            //if (tap.phase == TouchPhase.Ended && touchTime < 0.3f && player.GetComponent<HealthManager>().dashing == false)
            //{
            //    //lastTouch = null;
            //    Debug.Log("jump (early)");
            //    Jump();
            //}
            //if (tap.phase == TouchPhase.Moved)
            //{
            //    lastTouch = tap.position;
            //    Movement(); // function that runs if move is strong enough
            //}

            if (touching && touchTime > 0.1f && delayedJumpDebounce == false &&  player.GetComponent<HealthManager>().dashing != true)
            {
                delayedJumpDebounce = true;
                Debug.Log("jump(late)"+ touchTime);
                Jump();
            }
            if (tap.phase == TouchPhase.Ended && touchTime < 0.1f && player.GetComponent<HealthManager>().dashing != true)
            {
                Debug.Log("jump(normally)");
                Jump();
                //Debug.Log(player.GetComponent<HealthManager>().dashing);
            }
            if (tap.phase == TouchPhase.Moved)
            {
                lastTouch = tap.position;
                Movement(); // function that runs if move is strong enough
            }


            if (tap.phase == TouchPhase.Began)
            {             
                touching = true;
                touchTime = 0f;
                firstTouch = tap.position;
            }

            if (tap.phase == TouchPhase.Ended)
            {
                delayedJumpDebounce = false;
                //jumpinitialtime = 1; //
                //Debug.Log("ended");
                touching = false;
                //Debug.Log("touched for"+touchTime);
            }



        }

        if (player.GetComponent<HealthManager>().dashing == true)
        {

            //touchTime = 0;
            //touchTime = 1;
            rb.velocity += dash * Vector3.right;
            
            dashTimer += Time.deltaTime;
            if (dashTimer > dashLength) //dash length in seconds
            {
                Debug.Log("dash ended");
                player.GetComponent<HealthManager>().dashing = false;
                dashTimer = 0;
            }

        }

    }

    void Jump()
    {

        //jumpinitialtime = (Time.time - jumpcooldowntimer);
        //jumpcooldowntimer = Time.time;
        //Debug.Log(jumpinitialtime);
        //if (jumpinitialtime > 0.3)
        //{   

            //jumping == true;

            if (isGrounded < count)
            {
                    isGrounded++;
                    //firstTouch = tap.position;
                    //lastTouch = tap.position;
                    rb.velocity += force * Vector3.up;

                    Camera.main.GetComponent<AudioSource>().PlayOneShot(skateJump, 1.0f);
            }

        //}
    }

    void Movement() {
        if ( (Mathf.Abs(lastTouch.x - firstTouch.x) > dragDistance || Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance) && player.GetComponent<HealthManager>().dashing == false) {
            Debug.Log("dash started");
            player.GetComponent<HealthManager>().dashing = true;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(dashSound, 1.0f);
            //touchTime = 0;
            //rb.velocity += dash * Vector3.right;
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(skateJump, 1.0f);
        }
    }
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
