using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    public static Dictionary<string, Dictionary<string, float>> playerScores;
    // Start is called before the first frame update
    public static int changeCounter = 0;
    void Awake() {
        if(instance == null){
            instance = this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Init();
    }

    public static void Init(){
        if(playerScores!=null){
            return;
        }
        playerScores = new Dictionary<string, Dictionary<string, float>>();
    }
    public static float GetScore(string username, string scoreType){
        Init();

        if(playerScores.ContainsKey(username)==false){
            return 0;
        }

        if(playerScores[username].ContainsKey(scoreType)==false){
            return 0;
        }
        return playerScores[username][scoreType];
    }

    public static void SetScore(string username, string scoreType, float value){
        Init();
        changeCounter++;
        if(playerScores.ContainsKey(username)==false){
           playerScores[username] = new Dictionary<string, float>();
        }
        playerScores[username][scoreType] = value;
    }

    public static void ChangeScore(string username, string scoreType, float amount){
        Init();
        float currScore = GetScore(username, scoreType);
        SetScore(username, scoreType, amount);
    }

    public static string[] GetPlayerNames(){
        //sort and get the player names
        Init();
        return playerScores.Keys.OrderByDescending(n=> GetScore(n, "score")).ToArray();
    }

    public static int GetChangeCounter(){
        return changeCounter;
    }
}
