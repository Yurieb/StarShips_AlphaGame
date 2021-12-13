using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   
    int HitScore = 50;
    public int score;
    public Text ScoreUI;
    // Update is called once per frame
    void Start()
    {
        ScoreUI.text = score.ToString();
        
    }

    public void AddScore()
    {
        score = score + HitScore;
        ScoreUI.text = score.ToString();
    }
}
