using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public Text highscoreText;

     void Start()
    {
        highscoreText.text = "Highscore : " + (int)PlayerPrefs.GetFloat("ScoreText");
    }


    public void PlayGame() {
		SceneManager.LoadScene ("Gameplay");
	}
}
