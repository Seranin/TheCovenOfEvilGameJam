using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //Go to next scene; which can be found in File -> Build settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        //Go to scene 3 (should be game)
        SceneManager.LoadScene(2);
    }
    public void MainMenuGame()
    {
        //Go to scene 1 (should be main menu)
        SceneManager.LoadScene(0);
    }
}
