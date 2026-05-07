using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public GameObject GameOverUI;
   

    [SerializeField] private TextMeshProUGUI TimerCounter;
    [SerializeField] private TextMeshProUGUI KillCounter;

    public static UI instance;

    private int killCount;


    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }


    private void Update()
    {
        TimerCounter.text = Time.time.ToString("F2") + "s";
    }


    public void RestartLevel()
    {

        int sceenIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceenIndex);

    }



    public void EnableGameOverScrene()
    {
        Time.timeScale = .5f;
        GameOverUI.SetActive(true);


    }

    public void AddKillCount()
    {
        killCount++;
        KillCounter.text = killCount.ToString();
    }

}
