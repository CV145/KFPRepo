using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{

    /// <summary>
    /// The glasses lot lizard's projectile, when enabled, hones in on the player.
    /// If it hits the player, damage the player then disable self. Otherwise disable self after a set amount of time.
    /// </summary>
    /// 
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Flipper))]
    public class GlassesLLProjectile : MonoBehaviour
    {
        [SerializeField] float chaseSpeed;
        Transform player;
        Vector2 directionOfPlayer;
        Mover mover;
        Flipper flipper;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            mover = GetComponent<Mover>();
            flipper = GetComponent<Flipper>();
            flipper.ObjToFace = player;
        }

        private void Update()
        {
            //if (flipper.FacingRight)
            //    mover.MoveRight(chaseSpeed);
            //else
            //    mover.MoveLeft(chaseSpeed);

            mover.MoveTo(player, chaseSpeed);
        }
    }
}