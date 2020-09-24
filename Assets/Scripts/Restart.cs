using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour {

    public GameObject submitDisplay;
    public Button restartButton;
    public Button submitScoreButton;
    public Button quitToMenuButton;
    
    void Start(){
		restartButton.onClick.AddListener(RestartGame);
        submitScoreButton.onClick.AddListener(SubmitScore);
        quitToMenuButton.onClick.AddListener(QuitGame);
    }
	void RestartGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    void SubmitScore(){
        PlayerPrefs.SetString("setDisplay", "leaderboard");
        submitDisplay.SetActive(true);
    }

    void QuitGame(){
        PlayerPrefs.SetString("setDisplay", "mainMenu");
        SceneManager.LoadScene("Menu");
    }
}
