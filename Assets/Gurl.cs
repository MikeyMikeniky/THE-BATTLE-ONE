using Unity.VisualScripting;
using UnityEngine;

public class Gurl : Entity
{

    [SerializeField] private int Health = 10;

    private Transform player;

    protected override void Awake()
    {
        base.Awake();
        player = FindAnyObjectByType<Player>().transform;

    }
    
    protected override void Update()
    {
        handleflip();

    }

    protected override void handleflip()
    {

        if (player.transform.position.x > this.transform.position.x && facingRight == false)
        {
            flip();
        }

        if (player.transform.position.x < this.transform.position.x && facingRight == true)
        {
            flip();
        }

    }
}
