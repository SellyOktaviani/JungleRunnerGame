using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    public Text highscoreText;

    void Start()
    {
        highscoreText.text = "Highscore : " + (int)PlayerPrefs.GetFloat("ScoreText");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void SceneHelp()
    {
        SceneManager.LoadScene("Help");
    }

    public void SceneCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void Close()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
