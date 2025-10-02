using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void playGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

     public void exitGame()
    {
        Debug.Log("Exit Level");
        Application.Quit();
    }
    


}
