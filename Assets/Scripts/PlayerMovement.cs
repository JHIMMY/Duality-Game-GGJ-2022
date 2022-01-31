using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;

    public float jumpForce;
    private float moveInput;

    public LayerMask whatIsGround;
    public Transform feetPos;
    public float checkRadius;
    private bool isGrounded;
    private bool isFalling;
    private bool isJumping;

    private AudioSource au;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sp;
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip landClip;

    [SerializeField] ParticleSystem jumpParticles;
    [SerializeField] ParticleSystem landParticles;

    public bool FreezeUpdate { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        au = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Interaction.OnDialogStarted += FreezeUpdating;
        DialogManager.OnDialogFinished += UnfreezeUpdating;
    }

    private void OnDisable()
    {
        Interaction.OnDialogStarted -= FreezeUpdating;
        DialogManager.OnDialogFinished -= UnfreezeUpdating;

    }

    private void FreezeUpdating()
    {
        FreezeUpdate = true;
        moveInput = 0;
        rb.velocity = Vector3.zero;
        animator.SetFloat("IdleSpeedAstro", 1);
        animator.enabled = false;
    }

    private void UnfreezeUpdating()
    {
        FreezeUpdate = false;
        animator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (FreezeUpdate == false)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            if (moveInput == 0)
                animator.SetFloat("IdleSpeedAstro", 1);
            FaceMoveDirection();
            Jump(); 
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (rb.velocity.sqrMagnitude > 0)
            animator.SetFloat("IdleSpeedAstro", 2);
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);        
        
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;

            isJumping = true;
            jumpParticles.Play();
            animator.SetTrigger(JumpKey);
            au.PlayOneShot(jumpClip);
        }

        if (!isGrounded && isJumping)
        {
            isFalling = true;
        }

        if (isFalling && isJumping && isGrounded)
        {
            isFalling = false;
            isJumping = false;
            landParticles.Play();
            animator.SetTrigger(GroundedKey);
            au.PlayOneShot(landClip);
        }




    }

    void FaceMoveDirection()
    {
        if (moveInput > 0)
        {
            sp.flipX = false;
        }
        else if (moveInput < 0)
        {
            sp.flipX = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feetPos.position, checkRadius);
    }

    #region Animation Keys

    private static readonly int GroundedKey = Animator.StringToHash("GroundedAstro");
    private static readonly int IdleSpeedKey = Animator.StringToHash("IdleSpeedAstro");
    private static readonly int JumpKey = Animator.StringToHash("JumpAstro");

    #endregion
}
