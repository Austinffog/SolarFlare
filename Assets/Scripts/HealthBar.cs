using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        health = PlayerPrefs.GetFloat("health", health); //gets the playerpref amount for health
        healthBar.fillAmount = health / 100; //makes the image of the healthbar appear less based on the health amount
    }
}
