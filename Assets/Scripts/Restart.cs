using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    public GameObject submitDisplay;
	void Update () {
        //restart when user presses R
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.GetKeyDown(KeyCode.T)){
            PlayerPrefs.SetString("setDisplay", "leaderboard");
            submitDisplay.SetActive(true);
            // SceneManager.LoadScene("Menu");
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            PlayerPrefs.SetString("setDisplay", "mainMenu");
            SceneManager.LoadScene("Menu");
        }
	}
}
