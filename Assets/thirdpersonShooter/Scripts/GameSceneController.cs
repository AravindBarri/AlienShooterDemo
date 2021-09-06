using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public GameObject HomeScreen;
    public GameObject OptionsMenu;
    public GameObject HelpMenu;
    public void start()
    {
        SceneManager.LoadScene(1);
    }
    public void Home()
    {
        HomeScreen.SetActive(true);
        OptionsMenu.SetActive(false);
        HelpMenu.SetActive(false);
    }
    public void HomeMenu()
    {
        HomeScreen.SetActive(true);
        OptionsMenu.SetActive(false);
        HelpMenu.SetActive(false);
    }
    public void OptionScreen()
    {
        HomeScreen.SetActive(false);
        OptionsMenu.SetActive(true);
        HelpMenu.SetActive(false);
    }
    public void HelpScreen()
    {
        HomeScreen.SetActive(false);
        OptionsMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }
}
