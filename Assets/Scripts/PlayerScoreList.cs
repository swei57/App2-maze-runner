using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour
{

    public GameObject playerScoreEntryPrefab;
    int lastChangeCounter;

    // Start is called before the first frame update
    void Start(){
        lastChangeCounter = ScoreManager.GetChangeCounter();
        ScoreManager.SetScore(PlayerPrefs.GetString("setName"), "score", float.Parse(PlayerPrefs.GetString("setScore")));
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreManager.GetChangeCounter() == lastChangeCounter){
            //nothing changed in the scoreboard since last update call
            return;
        }

        lastChangeCounter = ScoreManager.GetChangeCounter();
        //clearing children
        while(this.transform.childCount > 0){
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }

        string[] names = ScoreManager.GetPlayerNames();
        foreach(string name in names){
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("Username").GetComponent<Text>().text = name;
            go.transform.Find("Score").GetComponent<Text>().text = ScoreManager.GetScore(name, "score").ToString();
        }
    }
}
