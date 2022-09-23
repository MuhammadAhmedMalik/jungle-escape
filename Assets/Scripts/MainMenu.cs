using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public GameObject ClickPauseButton;
    public void PlayGameLevel1()
    {

        SceneManager.LoadScene("Level 1");
    }

    public void PlayGameLevel2()
    {

        SceneManager.LoadScene("Level 2");
    }
    public void PlayGameLevel3()
    {

        SceneManager.LoadScene("Level 3");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void onPauseClick()
    {
        Time.timeScale = 0;
        ClickPauseButton.SetActive(true);
    }

    public void OnResumeClick()
    {
        Time.timeScale = 1;
        ClickPauseButton.SetActive(false);
    }
    public void OnRestartClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ClickPauseButton.SetActive(false);
    }

    public void OnExitClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
        ClickPauseButton.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void OnClickNextEvent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
