using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    private string storeID = "3538567";
    private string videoID = "video";

    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(storeID, false);
    }

    public void adPlay()
    {
        if (Advertisement.IsReady(videoID))
        {
            var options = new ShowOptions { resultCallback = Options };
            Advertisement.Show(videoID, options);
        }

        if (!Advertisement.IsReady(videoID))
        {
            SceneManager.LoadScene("Level 1");
            health = 100f;
            PlayerPrefs.SetFloat("health", health);
        }
    }

    private void Options(ShowResult result)
    {
        SceneManager.LoadScene("Level 1");
        health = 100f;
        PlayerPrefs.SetFloat("health", health);
    }
}