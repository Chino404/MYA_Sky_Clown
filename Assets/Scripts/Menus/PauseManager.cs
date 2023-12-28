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
    bool _isGameOver;

    public static int lastScene;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        lastScene = SceneManager.GetActiveScene().buildIndex;

        Debug.Log(lastScene);
        Time.timeScale = 1;
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
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
        if (_isGameOver)
        {
            gameOverCanvas.SetActive(false);
        }
        else
        pauseMenu.SetActive(false);

        Time.timeScale = 1;
           
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLvL()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
