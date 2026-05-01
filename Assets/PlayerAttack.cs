using System.Runtime.CompilerServices;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private GameObject attackArea = default;
    private bool Attacking = false;
    private float timeTAttack = .25f;
    private float timer;
    private void start()
    {
        attackArea = transform.GetChild(0).gameObject;

    }


}
