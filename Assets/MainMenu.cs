using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Game"); // go from sceneNum = 0(main menu) to sceneNum = 1(game)
    }   
    public void goToInstructions()
    {
        SceneManager.LoadScene("InstructionsScreen");
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void goToCredits()
    {
        SceneManager.LoadScene("CreditsScreen");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
