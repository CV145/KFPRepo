using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Peso script. Pesos move in a circle before moving to the player.
/// </summary>
/// 
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
public class Peso : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Transform player;
    Mover mover;
    Rotator rotator;
    bool chasePlayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mover = GetComponent<Mover>();
        rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        rotator.Rotate();
        if (chasePlayer)
        {
            mover.MoveTo(player, moveSpeed);
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 0.1f)
        {
            PesoSystem.Pesos += 1;
            Destroy(gameObject);
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
