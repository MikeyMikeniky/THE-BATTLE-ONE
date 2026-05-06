using UnityEditor.Build;
using UnityEngine;

public class EntityAnimationEvents : MonoBehaviour
{
    private Entity entity;


    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }



    public void DamageTargets() => entity.DamageTargets();
    private void disableJumpandMove() => entity.EnableMoveandJump(false);
 
    private void EnableJumpandMove() => entity.EnableMoveandJump(true);
    

}
