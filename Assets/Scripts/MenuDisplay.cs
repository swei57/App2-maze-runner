using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisplay : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject leaderboardMenu;

    void Start()
    {
        if(PlayerPrefs.GetString("setDisplay")=="leaderboard"){
            leaderboardMenu.SetActive(true);
            mainMenu.SetActive(false);
        }else
        {
            leaderboardMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
