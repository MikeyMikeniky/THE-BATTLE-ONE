using Unity.VisualScripting;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] respawnPoints;
    public float cooldown = 2.0f;
    [SerializeField] private float timer;

    [SerializeField] public float coolDownCap = .07f;
    [SerializeField] public float coolDownDecreaseRate = .05f;


    private Transform player;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>().transform;
    }

    private void Update()
    {
        
        timer -= Time.deltaTime;



        if(timer < 0)
        {

            CreateNewEnemy();
            timer = cooldown;
            
        }
    }

    private void CreateNewEnemy()
    {
        int respawnPointsIndex = Random.Range(0, respawnPoints.Length);

        GameObject newEnemy = Instantiate(prefab, respawnPoints[respawnPointsIndex].position, Quaternion.identity);



        bool CreatedOnTheRight = newEnemy.transform.position.x > player.transform.position.x;

        if (CreatedOnTheRight)
        {

            newEnemy.GetComponent<Enemy>().flip();
        }
    }
}
