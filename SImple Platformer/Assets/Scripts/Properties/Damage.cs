using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;                                      // The total damage dealt.
    public List<string> tagNames;                           // Tag names of the gameObjects that can be damaged.

    private bool _canDamage;

    private void Start()
    {
        _canDamage = true;
        Debug.Log("Damage Implimented");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");

        if (tagNames.Contains(collision.gameObject.tag) && _canDamage)
        {
            Debug.Log("GameObject Received Damage! ");
            collision.gameObject.GetComponent<Health>().ReceiveDamage(damage);
        }
    }
}
