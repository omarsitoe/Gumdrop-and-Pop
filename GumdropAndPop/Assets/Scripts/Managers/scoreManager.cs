using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UIElements;

public class scoreManager : MonoBehaviour
{
    private int score;
    private int highScore = 0;

    public Text scoreText;
    public Text hsText;
    
    void Start() {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    void Update() {
        // Keep track of highScore
        if(score > highScore) {
            highScore = score;

            // Save HighScore
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        // Display
        hsText.text     = "HighScore:  " + highScore;
        scoreText.text  = "Score:       " + score;
        

        // DEBUGGING
        if(Input.GetKeyDown("space"))
            AddScore(100);
    }

    public void AddScore(int toAdd) {
        if(toAdd < 0) {
            Debug.Log("Invalid score increase");
            return;
        }
        score += toAdd;
    }
}
