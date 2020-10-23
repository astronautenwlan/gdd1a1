using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCalculateScoreScript : MonoBehaviour
{
    public Text score_field_;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerScoreThisGame", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // update the enemies defeated text field
        Text enemies_defeated_text = score_field_.GetComponent<Text>();
        enemies_defeated_text.text = "Enemies Defeated: " + PlayerPrefs.GetInt("PlayerScoreThisGame");
        
        // update the player prefs highscore
        int high_score = PlayerPrefs.GetInt("HighScore");
        int player_score = PlayerPrefs.GetInt("PlayerScoreThisGame");
        if (player_score > high_score)
        {
            PlayerPrefs.SetInt("HighScore", player_score);
        }

    }
}
