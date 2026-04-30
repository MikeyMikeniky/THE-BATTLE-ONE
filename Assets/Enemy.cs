using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public string enemyName;


    private void Awake()
    {
        

    }



    public void Update()
    {
        moveAround();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();

        }

    }





    public void moveAround()
    {

        Debug.Log(enemyName+ "moves at speed" +  moveSpeed);

    }
    public virtual void Attack()
    {

        Debug.Log(enemyName + "Attacks!");

    }

    public void takeDamage()
    {

        Debug.Log("Ive Been hit!");


    }

    public string GetEnemyName()
    {

        return enemyName;

    }


}
