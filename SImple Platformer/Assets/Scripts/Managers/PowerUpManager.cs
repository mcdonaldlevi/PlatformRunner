using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // Stats private, set from PowerUp class.
    bool _regenHealth;                      
    bool _doublePoints;

    bool _powerUpActive;                    // Power up is active or not.
    float _powerUpLengthCounter;            // Tracks how long the power up has been active.

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivatePowerUp(Dictionary<string, bool> powerUps, float time)
    {
        _regenHealth = powerUps["RegenHP"];
        _doublePoints = powerUps["DoublePoints"];
        _powerUpLengthCounter = time;
    }
}
