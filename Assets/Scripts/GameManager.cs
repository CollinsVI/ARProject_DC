using UnityEngine;
using TMPro; // Import this if you're using TextMeshPro for the text UI.

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public float gameDuration = 60f; // 60 seconds
    private float timeRemaining;

    public TextMeshProUGUI ScoreText; // Drag your ScoreText UI object here in the Inspector.
    public TextMeshProUGUI TimerText; // Drag your TimerText UI object here in the Inspector.

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

        // Initialize UI text
        UpdateScoreText();
        UpdateTimerText();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        // Update the timer UI
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

        // Update the score UI
        UpdateScoreText();
    }

    void EndGame()
    {
        Debug.Log("Game Over! Final Score: " + score);
        // Add additional logic to reset the game or show a game over screen
        Time.timeScale = 0f;
    }

    // Helper method to update the score text
    void UpdateScoreText()
    {
        if (ScoreText != null)
        {
            ScoreText.text = "Score: " + score;
        }
    }

    // Helper method to update the timer text
    void UpdateTimerText()
    {
        if (TimerText != null)
        {
            TimerText.text = "Time: " + Mathf.CeilToInt(timeRemaining); // Rounds up for cleaner display.
        }
    }
}
