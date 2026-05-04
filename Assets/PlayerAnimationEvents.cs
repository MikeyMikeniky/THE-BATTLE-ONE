using UnityEditor.Build;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Entity player;


    private void Awake()
    {
        player = GetComponentInParent<Entity>();
    }



    public void DamageTargets() => player.DamageTargets();
    private void disableJumpandMove() => player.EnableMoveandJump(false);
 
    private void EnableJumpandMove() => player.EnableMoveandJump(true);
    

}
