using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject gameOverMenu;
    private float distance = 10f;
    public float timer = 5f;
    private static float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        health = PlayerPrefs.GetFloat("health", health);
    }

    private void OnParticleCollision(GameObject collision)
    {

        if (collision.gameObject.CompareTag("Planet")) //if a particle collides with the Planet
        {
            health -= 0.5f;
            PlayerPrefs.SetFloat("health", health);
        }
        else if (!collision.gameObject.CompareTag("Planet") && collision.gameObject.CompareTag("Asteroid"))
        {
            Invoke("NextLevel", timer);
        }

        if (health == 0f)
        {
            Destroy(collision.gameObject);
            GameOver();
        }
    }

    private void OnMouseDrag()
    {
        if (gameObject.CompareTag("Asteroid"))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = objPosition;
        }
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void PlayAgain()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Level 1");
        health = 100f;
        PlayerPrefs.SetFloat("health", health);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
