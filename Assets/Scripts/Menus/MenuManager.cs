using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject playButton;
   
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void TutorialLevel()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;

    }

}
