using UnityEngine;

public class Enemy : Entity
{
    protected override void Update()
    {
        handeAnimation();
        handleflip();
        handleCoilisons();
        handleInput();
    }



    protected override void handleInput()
    {
        if (canMove)
        {
            //Running
            rb.linearVelocity = new Vector2(FaceDir, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        }

    }
}