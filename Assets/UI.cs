using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerCounter;
    [SerializeField] private TextMeshProUGUI KillCounter;

    public static UI instance;

    private int killCount;


    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        TimerCounter.text = Time.time.ToString("F2") + "s";
    }



    public void AddKillCount()
    {
        killCount++;
        KillCounter.text = killCount.ToString();
    }

}
