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
    public TextMeshProUGUI GameOverText; // Game Over text reference

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

        // Ensure GameOverText is hidden at the start
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false);
        }
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

        // Enable the GameOverText and display the score
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(true); // Enable the GameOverText object
            GameOverText.text = "Game over! You may become a Pirate Yet! Your Score was: " + score.ToString();
        }

        // Set Time.timeScale to 0 after enabling the GameOverText to avoid any issues
        Time.timeScale = 0f;
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
