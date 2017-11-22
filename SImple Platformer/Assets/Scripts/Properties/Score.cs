using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public bool scoreIncreasing;                            // The entity's score increasing.
    public int pointsPerSecond;                             // The points the entity can gain per second.
    private float _currentScore;                            // The current health of the entity.

    public float CurrentScore
    {
        get
        {
            return _currentScore;
        }
    }

    void Start()
    {
        // Initial score is zero.
        _currentScore = 0;
    }

    void Update()
    {
        // Increase score by pointsPerSecond if allowed.
        if (scoreIncreasing && gameObject.activeInHierarchy)
        {
            _currentScore += pointsPerSecond * Time.deltaTime;
        }
    }

    /// <summary>
    /// Adds the score parameter to the current score of the 
    /// entity.
    /// </summary>
    /// <param name="score">The score to add to the current score.</param>
    public void AddScore(int score)
    {
        _currentScore += score;
    }
}
