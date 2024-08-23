using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highScoreText; // Reference to the high score UI text

    private int score = 0;
    private int highScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreUI();
    }

    public void AddScore(int increment)
    {
        score += increment;
        scoreText.text = "Score: " + score.ToString();

        // Check if the current score is higher than the high score
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Save the new high score
            UpdateHighScoreUI();
        }
    }

    void UpdateHighScoreUI()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    // Optionally, you can add a reset method if you want to reset the high score
    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("HighScore", highScore);
        UpdateHighScoreUI();
    }
}
