using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // UI Elements
    public Image healthImageBG;
    public Image healthImageFG;                     
    
    public string tagName;                              // The player that the health manager is associated to.

    private Health _playerHealth;                       // The health class attached to the player.
    private int _hpValue;                               // The previous health of the object


    private void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag(tagName).GetComponent<Health>();
        _hpValue = _playerHealth.CurrentHP;
        UpdateGUI();
    }

    private void Update()
    {
        if (_hpValue != _playerHealth.CurrentHP)
        {
            UpdateGUI();
        }
    }

    /// <summary>
    /// Updates the graphical user interface.
    /// </summary>
    private void UpdateGUI()
    {
        float percent = (float)_playerHealth.CurrentHP / _playerHealth.maxHP;
        healthImageFG.fillAmount = percent;
    }
}
