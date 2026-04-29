using UnityEditor.Build;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private PlayerVelocity player;


    private void Awake()
    {
        player = GetComponentInParent<PlayerVelocity>();
    }



    public void DamageEnemies() => player.DamageEnemies();
    private void disableJumpandMove() => player.EnableMoveandJump(false);
 
    private void EnableJumpandMove() => player.EnableMoveandJump(true);
    

}
