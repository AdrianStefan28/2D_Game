using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject info;

 
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("LoadGame", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MyGame");
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("LoadGame", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MyGame");
        Time.timeScale = 1;
    }

    public void GoToLeaderboard()
    {
        mainMenu.SetActive(false);
        info.SetActive(false);
    }

    public void GoToInfo()
    {
        info.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void GoToMenu()
    {
        mainMenu.SetActive(true);
    }
}
