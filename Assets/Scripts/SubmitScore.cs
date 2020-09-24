using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitScore : MonoBehaviour
{
    public InputField playerName;
    public Button mybutton;

    void Start() {
    Button btn = mybutton.GetComponent<Button>();
		btn.onClick.AddListener(SetPlayerName);
    }

    void SetPlayerName(){
        Debug.Log(playerName.text);
        PlayerPrefs.SetString("setName", playerName.text);
    }
}
