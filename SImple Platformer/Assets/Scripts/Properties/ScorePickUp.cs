using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickUp : MonoBehaviour
{
    public int scoreBoost;                                          // The amount to boost.
    public List<string> tagNames;                                   // The entity tag names that can pick up the gameObject.

    private bool _pickedUp;                                         // Check when colliding if it is picked up to avoid multiple collisions.

    private void Start()
    {
        Debug.Assert(null != tagNames);
        _pickedUp = false;
    }

    /// <summary>
    /// If a player touches the gameobject containing this PickUp
    /// script, the object's score will be updated.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagNames.Contains(collision.gameObject.tag) && !_pickedUp)
        {
            Debug.Log("Adding scoreBoost " + scoreBoost + " to CurrentScore" + collision.gameObject.GetComponent<Score>().CurrentScore);
            collision.gameObject.GetComponent<Score>().AddScore(scoreBoost);
            Debug.Log("Current Score: " + collision.gameObject.GetComponent<Score>().CurrentScore);
            gameObject.SetActive(false);
            _pickedUp = true;
        }
    }
}
