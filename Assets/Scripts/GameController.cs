using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Movement movement;
    public GunControl bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverMenu()
    {
        Time.timeScale = 0;
        movement.isPauseGame = !movement.isPauseGame;
        bullet.isPauseGame = !bullet.isPauseGame;
        gameOverPanel.SetActive(true);

    }
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        movement.isPauseGame = !movement.isPauseGame;
        bullet.isPauseGame = !bullet.isPauseGame;
        Time.timeScale = 1;
    }
}
