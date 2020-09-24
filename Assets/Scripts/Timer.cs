using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    private float startTime;
    private float score;
    private float levelMaxTime;
    private float levelScore;
    private bool finished = false;
    private float time;
    public GameObject restartDisplay;

    // Start is called before the first frame update
    void Start()
    {
     startTime = Time.time;   
     score = 0;
     levelMaxTime = 600;
     levelScore = 42;
    }

    // Update is called once per frame
    void Update()
    {
        if(finished){
            return;
        }
        //amount of time since timer started
        time = Time.time - startTime;
        string minutes = ((int) time / 60).ToString();
        string seconds = (time % 60).ToString("f2");

        timerText.text = minutes + ":" +seconds;
    }

    public void Finished(){
        finished = true;
        timerText.color = Color.green;
        //very simple scoring system, player awarded 100 points per remaining second in game
        score = Math.Max(0, levelMaxTime - time) * levelScore;
        scoreText.text = score.ToString();
        PlayerPrefs.SetString("setScore", scoreText.text);
        restartDisplay.SetActive(true);
    }
}
