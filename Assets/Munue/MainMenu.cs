using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public LevelLoader LevelTransition;

    public void PlayGame()
    {
        LevelTransition.LoadNextLevel();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

      

    public void Quitgame()
    {
        Application.Quit();
    }
}
