using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   

    private void Start()
    {
        
        //lastScene = SceneManager.GetActiveScene().buildIndex;

       
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayButton()
    {
        if (PauseManager.lastScene ==0)
            SceneManager.LoadScene(2);
        else
            SceneManager.LoadScene(PauseManager.lastScene);
        Time.timeScale = 1;
    }
    public void TutorialLevel()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
