using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level_1()
    {
        SceneManager.LoadScene("Tutorial 1");
    }

    public void Level_2()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level_3()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level_4()
    {
        SceneManager.LoadScene("Level 3");
    }
}
