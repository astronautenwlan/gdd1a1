using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenShowScoreScript : MonoBehaviour
{
    public Text highscore_field_;
    
    void Start()
    {
        // Update our Scoreboard
        int score = PlayerPrefs.GetInt("HighScore");
        Text high_score_text = highscore_field_.GetComponent<Text>();
        high_score_text.text = "HighScore: " + score;
    }
}
