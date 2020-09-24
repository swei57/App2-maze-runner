using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitScore : MonoBehaviour
{
    public InputField playerName;
    public Button mybutton;

    void Start() {
    Button btn = mybutton.GetComponent<Button>();
		btn.onClick.AddListener(SetPlayerName);
    }

    void SetPlayerName(){
        PlayerPrefs.SetString("setName", playerName.text);
        SceneManager.LoadScene("Menu");
    }
}
