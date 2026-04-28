using Unity.VisualScripting;
using UnityEngine;

public class PlayerVelocity : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator Anim;

    private bool facingRight = true;

    [Header("Speed Atribuites")]
    public float runSpeed = 5f;
    public float jumpForce = 3f;

    [Header("Colision detectioin")]
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask WhatIsGround;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponentInChildren<Animator>();
        
    }
    
    private void Update()
    {
        handeAnimation();
        handleflip();
        handleCoilisons();
        handleInput();
    }


    private void handleInput()
    {
        //Running
        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, rb.linearVelocity.y);

        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }

        //Atacking
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded == true)
        {
            Attack();


        }
    }
    private void Attack()
    {

        Anim.SetTrigger("Attack");
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

    }
    
    private void Jump()
    {

        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    }


    [ContextMenu("flip")]
    private void handleflip()
    {

        if (rb.linearVelocity.x > 0 && facingRight == false)
        {
            flip();
        }
       
        if (rb.linearVelocity.x < 0 && facingRight == true) 
        {
            flip();
        }
    }

    private void flip()
    {

        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));

    }
    private void handleCoilisons()
    {

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, WhatIsGround);

    }

    private void handeAnimation()
    { 
        Anim.SetBool("isGrounded", isGrounded);
        Anim.SetFloat("Y velocity", rb.linearVelocity.y);
        Anim.SetFloat("X velocity", rb.linearVelocity.x);
    }


}


