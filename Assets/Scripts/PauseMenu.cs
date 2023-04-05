using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseMenu;
    public Movement movement;
    public GunControl bullet;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        movement.isPauseGame = !movement.isPauseGame;
        bullet.isPauseGame = !bullet.isPauseGame;
    }

    void TogglePause()
    {
        movement.isPauseGame = !movement.isPauseGame;
        bullet.isPauseGame = !bullet.isPauseGame;

        if(pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
