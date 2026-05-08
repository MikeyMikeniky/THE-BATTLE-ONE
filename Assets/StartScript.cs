using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
   
    public void PlayGame()
    {

        SceneManager.LoadSceneAsync(1);
    }


}
