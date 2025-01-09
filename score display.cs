using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay Instance;

    public Text scoreText; // Reference to the UI Text component

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreDisplay(GameManager.Instance.GetScore()); // Initialize the score display
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = "Score: " + score; // Update the score text
    }
}
