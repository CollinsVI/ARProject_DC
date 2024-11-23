using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public float gameDuration = 60f; 
    private float timeRemaining;

    public TextMeshProUGUI ScoreText; 
    public TextMeshProUGUI TimerText; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timeRemaining = gameDuration;

        
        UpdateScoreText();
        UpdateTimerText();

    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        
        UpdateTimerText();

        if (timeRemaining <= 0f)
        {
            
            EndGame();

        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);

        
        UpdateScoreText();

    }

    void EndGame()
    {
        Debug.Log("Game Over! Final Score: " + score);
        
        Time.timeScale = 0f; //Temporary

    }

    
    void UpdateScoreText()
    {
        if (ScoreText != null)
        {
            ScoreText.text = "Score: " + score;
        }
    }

    
    void UpdateTimerText()
    {
        if (TimerText != null)
        {
            
            TimerText.text = "Time: " + Mathf.CeilToInt(timeRemaining); 

        }
    }
}
