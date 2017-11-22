using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healthBoost;                                         // The amount to health heal.
    public List<string> tagNames;                                   // The tag names that the item can boost.

    private bool _pickedUp;
    
    // Use this for initialization
    void Start()
    {
        _pickedUp = false;
    }

    /// <summary>
    /// If a player touches the gameobject containing this PickUp
    /// script, the object's health will be updated.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool validTag = tagNames.Contains(collision.gameObject.tag);

        if (validTag && !_pickedUp)
        {
            var health = collision.gameObject.GetComponent<Health>();
            health.Heal(healthBoost);

            gameObject.SetActive(false);
            _pickedUp = true;
        }
    }
}
