using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utilities;

/// <summary>
/// Requires a 2DCollider. Uses trigger collisions to damage the player whenever the collider of the game object this is attached to collides with the player.
/// 
/// </summary>
///
public class DamagePlayerCollider : MonoBehaviour
{
    [SerializeField] int damageToCause = 1;
    [SerializeField] bool destroySelfOnCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerHealth>().DecreaseHealth(damageToCause);

            if (destroySelfOnCollision)
            {
                GameObject.Destroy(this.gameObject);
            }
        }


    }
}
