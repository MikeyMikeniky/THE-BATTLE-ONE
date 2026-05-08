using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
public class Player : Entity
{


    [Header("Physical Atribuites")]
    [SerializeField] protected float runSpeed = 5f;
    [SerializeField] public float jumpForce = 3f;
    [SerializeField] private bool canJump = true;



    protected override void Awake()
    {
        base.Awake();
        Health = 10;
    }

    protected override void Update()
    {
        base.Update();
        handleInput();
       
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



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Enemy"))
    //    {
    //        Health -= Damage;
    //    }
    //    else
    //    {
    //        StartCoroutine(GetHurt());
    //    }
    //}

    //private IEnumerator GetHurt()
    //{
    //    Physics2D.IgnoreLayerCollision(6, 8, true);
    //    yield return new WaitForSeconds(3f);
    //    Physics2D.IgnoreLayerCollision(6, 8, false);
    //}

    protected override void takeDamage()
    {
        base.takeDamage();
       
        if (Health == 0)
        {
            UI.instance.EnableGameOverScrene();
        }
    }
}
