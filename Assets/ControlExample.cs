using System.Xml.Serialization;
using UnityEngine;

public class ControlExample : MonoBehaviour
{
    public float timer;



    private SpriteRenderer sr;
    public float redColourDuration = 1.0f;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        TimerThing();
    }

    private void TimerThing()
    {
        timer -= Time.deltaTime;


        if (timer < 0 && sr.color != Color.white)
        {
            sr.color = Color.white;

        }
    }

    public void takeDamage()
    {

        sr.color = Color.red;
        timer = redColourDuration;
    }

    

    private void TurnWhite()
    {
        sr.color = Color.white;
        
        
        
       


    }
}






