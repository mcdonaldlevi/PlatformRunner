using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP;                                   // Entity's maximum health.
    public float repeatDamagePeriod;                    // The amount of time to wait before dealing damage again.

    private int _currentHP;                             // The current health of the entity.
    private bool _canDamage;

    public int CurrentHP
    {
        get
        {
            return _currentHP;
        }
    }

    void Start()
    {
        Debug.Assert(0 != maxHP, "The maximum HP CANNOT be zero!");
        _currentHP = 50;
        //_currentHP = maxHP;
    }

    private void Update()
    {
        CheckStatus();
    }

    /// <summary>
    /// Updates the entity's current status.
    /// </summary>
    private void CheckStatus()
    {
        if (_currentHP > maxHP)
        {
            _currentHP = maxHP;
        }
        if (_currentHP < 0)
        {
            _currentHP = 0;
        }
        if (_currentHP == 0)
        {
            //DEATH!
        }
    }

    /// <summary>
    /// Adds health for the player with a parameter value.
    /// </summary>
    /// <param name="health">The health to add.</param>
    public void Heal(int health)
    {
        if (gameObject.activeInHierarchy)
        {
            _currentHP += health;
        }
    }

    /// <summary>
    /// Removes health from the player with a parameter value.
    /// </summary>
    /// <param name="damage">The amount of damage to take.</param>
    public void ReceiveDamage(int damage)
    {
        if (gameObject.activeInHierarchy)
        {
            _currentHP -= damage;
            StartCoroutine("DisableDamageCoroutine");
        }
    }

    /// <summary>
    /// Method that waits specified amount of time before 
    /// </summary>
    /// <returns></returns>
    private IEnumerator DisableDamageCoroutine()
    {
        yield return new WaitForSeconds(repeatDamagePeriod);
        Debug.Log("Disabled Damage for " + repeatDamagePeriod + " seconds");
        _canDamage = true;
    }
}
