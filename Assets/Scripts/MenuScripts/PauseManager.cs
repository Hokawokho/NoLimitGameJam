using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    [SerializeField]private AudioSource music;


    void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (GameIsPaused)
                Resume();

            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        if (music != null)
            music.UnPause();

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        if (music != null)
            music.Pause();


    }

    public void RestartLevel()
    {
        Debug.Log("Restarting Level");

        //Meter nivel actual
        string mapa = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(mapa, LoadSceneMode.Single);
        //Resume();

    }

    public void QuitLevel()
    {
        Debug.Log("Exit Level");
        //Meter nivel inicial
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }
}
