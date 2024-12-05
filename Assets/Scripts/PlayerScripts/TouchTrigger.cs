using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    TapReader tapScript = new TapReader();
    public float jumpForce;
    public float dashForce;

   // public bool dashing;

    public int jumpCount;
    public float screenPercent;

    public float speed = 10.0f;
    public float maxSpeed = 10.0f;

    AudioSource audioSource;
    AudioSource skateLoopAudioSource;
    public AudioClip dashSound;
    public AudioClip skateRoll;
    public AudioClip skateJump;
    public AudioClip skateLand;

    Rigidbody rb;

    Animator animator;

    void Start() {
        rb = GetComponent<Rigidbody>(); tapScript.rb = rb;
        tapScript.playerAnimator = GetComponent<Animator>();
        tapScript.player = gameObject;
        audioSource = Camera.main.GetComponent<AudioSource>();
        skateLoopAudioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        jumpCount = jumpCount - 1;

        tapScript.dash = dashForce;
        tapScript.force = jumpForce;
        tapScript.count = jumpCount;
        tapScript.dragDistance = Screen.height * screenPercent/100;

        tapScript.dashSound = dashSound;
        tapScript.skateRoll = skateRoll;
        tapScript.skateJump = skateJump;
        tapScript.skateLand = skateLand;

    }
    // Update is called once per frame
    void Update()
    {
        tapScript.Tap();
        KeyboardControl();
        rb.velocity += new Vector3(1 - ((rb.velocity.x - maxSpeed) / 2), 0, 0);// Vector3.right - (rb.velocity.x - maxSpeed);

        if (tapScript.touching == true)
        {
            tapScript.touchTime += Time.deltaTime;          
        }

        /*if (tapScript.isGrounded == 0)
        {
            //skateLoopAudioSource.volume = 1.0f;
        }
        else
        {
            //skateLoopAudioSource.volume = 0.0f;
        }

        if (tapScript.touching == true && Time.time > tapScript.touchTime)
        {
            //tapScript.touchTime = Time.time + 0.3f;
            //Instantiate(projectile, transform.position, transform.rotation);
        }
        else if (tapScript.touching == true)
        {

        }*/

        RaycastHit hit;
        Vector3 p1 = transform.position;//- new Vector3(0,0.4f,0);
        if (Physics.Raycast(p1,-transform.up, out hit, 1.4f))
        {
            skateLoopAudioSource.volume = 1.0f;
        }
        else
        {
            skateLoopAudioSource.volume = 0f;
        }
        Debug.DrawRay(p1, -transform.up* 1.4f, Color.yellow);

    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ground" && tapScript.isGrounded >= 1) { //&& tapScript.isGrounded >= tapScript.count) {
            tapScript.isGrounded = 0;
            audioSource.time = 0.5f;
            audioSource.PlayOneShot(skateLand, 1.0F);
            animator.SetTrigger("isGrounded");
        }
    }

    void KeyboardControl() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            tapScript.Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            tapScript.Movement();
        }
    }


}
