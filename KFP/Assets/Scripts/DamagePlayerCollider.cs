using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utilities;

/// <summary>
/// Requires a 2DCollider. Uses trigger collisions to damage the player whenever the collider of the game object this is attached to collides with the player.
/// 
/// </summary>
///
[RequireComponent(typeof(Destroyer))]
public class DamagePlayerCollider : MonoBehaviour
{
    [SerializeField] int damageToCause = 1;
    [SerializeField] bool destroySelfOnCollision;
    [SerializeField] bool disableCollider;
    Destroyer destroyer;

    private void Start()
    {
        destroyer = GetComponent<Destroyer>();
    }

    /// <summary>
    /// Don't hurt player if true.
    /// </summary>
    public bool DisableCollider { get => disableCollider; set => disableCollider = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!disableCollider)
            {
                GameObject player = collision.gameObject;
                if(player.GetComponent<PlayerHealth>())
                player.GetComponent<PlayerHealth>().DecreaseHealth(damageToCause);
            }
           

            if (destroySelfOnCollision)
            {
                destroyer.DestroySelf();
            }
        }


    }
}
