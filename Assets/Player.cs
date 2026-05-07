using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{


    [Header("Physical Atribuites")]
    [SerializeField] protected float runSpeed = 5f;
    [SerializeField] public float jumpForce = 3f;
    [SerializeField] private bool canJump = true;


    protected override void Update()
    {
        base.Update();
        handleInput();
       
    }


    private void Start()
    {

        Health = 9;
}


    private void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded == true)
        {
            Attack();
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true && canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    protected override void HandleMovments()
    {

        if (canMove)
        {
            //Running
            rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, rb.linearVelocity.y);
        }
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

    }


    public override void EnableMoveandJump(bool enable)
    {
        base.EnableMoveandJump(enable);



            canJump = enable;
       
    }

    protected override void takeDamage()
    {
        base.takeDamage();
       
        if (Health == 1)
        {
            UI.instance.EnableGameOverScrene();
        }
    }
}
