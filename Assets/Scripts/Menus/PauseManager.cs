using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverCanvas;
    public GameObject winCanvas;
    public static PauseManager instance;
    bool _isPaused;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!_isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                _isPaused = true;
            }
            else if(_isPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                _isPaused = false;
            }
        }
    }
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
