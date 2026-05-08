using UnityEngine;

public class Slime : MonoBehaviour
{

    private void Start()
    {

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

    




   


