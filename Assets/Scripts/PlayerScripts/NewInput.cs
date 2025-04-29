using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class NewInput : MonoBehaviour
{
    //input system
    public SkaterControls grim;
    InputAction jump, shift, swipe;

    //control variables
    public int speed, jumpForce, dashForce, jumpCount;
    public float dashLength;
    float dashTimer;

    //gameobject references
    Rigidbody rb;
    Animator anim;
    HealthManager healthManager;

    //checks
    int isGrounded;

    //audio
    AudioSource audioSource;
    AudioSource skateLoopAudioSource;
    public AudioClip dashSound;
    public AudioClip skateRoll;
    public AudioClip skateJump;
    public AudioClip skateLand;

    void Awake() {
        grim = new SkaterControls();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        healthManager = GetComponent<HealthManager>();
        audioSource = Camera.main.GetComponent<AudioSource>();
        skateLoopAudioSource = GetComponent<AudioSource>();
        skateLoopAudioSource.volume = 1.0f;
    }

    void Update() {
        rb.velocity += new Vector3(1 - ((rb.velocity.x - speed) / 2), 0, 0);
    }

    void OnEnable() {
        jump = grim.Player.Jump;
        jump.Enable();
        jump.started += Jump;

        shift = grim.Player.Shift;
        shift.Enable();
        shift.started += Shift;

        swipe = grim.Player.Swipe;
        swipe.Enable();
        swipe.performed += Swipe;
    }

    void OnDisable() {
        jump.Disable();
        shift.Disable();
        swipe.Disable();
    }

    
    //input voids
    void Jump(InputAction.CallbackContext context) {
        if (isGrounded < jumpCount) {
            isGrounded ++;
            rb.velocity = jumpForce * Vector3.up;
            audioSource.PlayOneShot(skateJump, 1.0f);
            anim.SetTrigger("isJumping");
        }
    }

    void Shift(InputAction.CallbackContext context) {
        healthManager.dashing = true;
        StartCoroutine(Dash());
    }

    void Swipe(InputAction.CallbackContext context) {
        if (healthManager.dashing == false && context.ReadValue<Vector2>().x > 5) {
            healthManager.dashing = true;
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash() {
        rb.velocity = dashForce * Vector3.right;
        audioSource.PlayOneShot(dashSound, 1.0f);
        anim.SetTrigger("isDashing");
        yield return new WaitForSeconds(dashLength);
        healthManager.dashing = false;
    }

    //collider
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground") && isGrounded >= 1) {
            isGrounded = 0;
            audioSource.time = 0.5f;
            audioSource.PlayOneShot(skateLand, 1.0F);
            anim.SetTrigger("isGrounded");
            skateLoopAudioSource.volume = 1f;
        }
    }
    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            skateLoopAudioSource.volume = 0f;
        }
    }
}
