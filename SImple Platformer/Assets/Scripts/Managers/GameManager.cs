using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, GameObject> _players;            // Players in the game.
    private Dictionary<string, Vector3> _playerSpawnPoints;     // The differnent player spawn point positions.

    // Use this for initialization
    void Start()
    {
        _players = new Dictionary<string, GameObject>()
        {
            {"Player1", GameObject.FindGameObjectWithTag("Player1")},
            {"Player2", GameObject.FindGameObjectWithTag("Player2")}
        };

        // Add each player transform to the spawn point array.
        _playerSpawnPoints = new Dictionary<string, Vector3>()
        {
            {"Player1", _players["Player1"].transform.position},
            {"Player2", _players["Player1"].transform.position}
        };
    }

    /// <summary>
    /// Restart the game by calling the RestartGameCouroutine.
    /// </summary>
    public void RestartGame()
    {
        StartCoroutine("RestartGameCoroutine");
    }

    /// <summary>
    /// A couratine for restarting the game.
    /// 
    /// Waits for half a second before resetting each player for death animations and stuff.
    /// 
    /// The foreach loop will iterate through the PlayerControllers and sets each player
    /// transform back to the starting potitions.  It will also re-activate each player
    /// so that they can be seen in the game.
    /// </summary>
    /// <returns></returns>
    public IEnumerator RestartGameCoroutine()
    {
        // Wait half a second before starting restart.
        yield return new WaitForSeconds(0.5f);

        // Set the spawn point of the two players
        _players["Player1"].transform.position = _playerSpawnPoints["Player1"];
        _players["Player2"].transform.position = _playerSpawnPoints["Player2"];

        // Set the players to active.
        _players["Player1"].SetActive(true);
        _players["Player2"].SetActive(true);
    }
}
