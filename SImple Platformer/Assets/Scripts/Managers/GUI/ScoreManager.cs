using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // UI elements
    public Text scoreText;
    public Text hiScoreText;

    public string tagName;                                                 // The player name that the score manager is associated to.

    private Score _entityScore;                                            // The score of the entity which is retreived by the tag name.
    private float _hiScoreCount;                                           // The high score value to display.

    void Start()
    {
        Debug.Assert(null != tagName);

        // Get the Score of the entity.
        _entityScore = GameObject.FindGameObjectWithTag(tagName).GetComponent<Score>();

        // Set the preferences.
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    void Update()
    {
        if (_entityScore.CurrentScore > _hiScoreCount)
        {
            _hiScoreCount = _entityScore.CurrentScore;
            PlayerPrefs.SetFloat("HighScore", _hiScoreCount);
        }
        UpdateGUI();
    }

    /// <summary>
    /// Updates the GUI text elements to the current score.
    /// </summary>
    void UpdateGUI()
    {
        scoreText.text = "Score: " + Mathf.Round(_entityScore.CurrentScore);
        hiScoreText.text = "Score: " + Mathf.Round(_hiScoreCount);
    }
}
