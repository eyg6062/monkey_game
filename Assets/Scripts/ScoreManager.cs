using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    int totalScore;

    public void Perfect()
    {
        score += 300;
        Debug.Log("score: " + score);
    }

    public void Good()
    {
        score += 250;
        Debug.Log("score: " + score);
    }


    public int GetScore()
    {
        return score;
    }
}
