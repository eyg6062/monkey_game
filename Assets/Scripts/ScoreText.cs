using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        int score = scoreManager.GetScore();

        Text scoreText = gameObject.GetComponent<Text>();

        scoreText.text = score.ToString();
    }


}
