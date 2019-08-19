using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Peso script. Pesos move in a circle before moving to the player.
/// </summary>
/// 
[RequireComponent(typeof(Mover))]
public class Peso : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Transform player;
    Mover mover;
    bool chasePlayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mover = GetComponent<Mover>();
    }

    private void Update()
    {
        if (chasePlayer)
        {
            mover.MoveTo(player, moveSpeed);
        }
    }

    /// <summary>
    /// When called, will move the Peso towards the player.
    /// </summary>
    public void ChasePlayer()
    {
        chasePlayer = true;
    }
}
