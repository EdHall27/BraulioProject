using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthControl : MonoBehaviour
{
    public float health = 2;
    public float Health { get {return health;} set{health = Mathf.Clamp(value,0,healthMax);} }
    public float healthMax = 14;
    public Image healthBar;

    public GameController gameController;

    private  void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float percentageLife = Health / healthMax;
        healthBar.fillAmount = percentageLife;
    }

    public void Damage()
    {
        health -= 10;
        if(health <= 0)
        {
            //gameController.GameOver();
            gameController.GameOverMenu();
            //gameController.gameOverPanel.gameObject.SetActive(true);
        }
        UpdateHealthBar();
    }

    public void RestoreHealth(float lifeCount)
    {
        health += lifeCount; 
        UpdateHealthBar();
    }


}
