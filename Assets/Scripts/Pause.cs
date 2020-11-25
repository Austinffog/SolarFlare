using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject pausedMenu;
    private float interval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Level"))
        {
            Destroy(gameObject, interval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Paused()
    {
        pausedMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Leave()
    {
        Application.Quit();
    }
}
