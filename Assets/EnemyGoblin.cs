using UnityEngine;

public class EnemyGoblin : Enemy
{




        private void StealMoney()
    {

        Debug.Log(enemyName + "stealss gold from player!");
    }


   public override void Attack()
    {
        base.Attack();

        StealMoney();
    }




   [ContextMenu("Steals Gold")]
    private void SpecaialAttack()
    {

        StealMoney();
        Attack();

    }


}
