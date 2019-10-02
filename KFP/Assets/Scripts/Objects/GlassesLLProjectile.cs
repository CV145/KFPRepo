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
    [RequireComponent(typeof(Rotator))]
    public class GlassesLLProjectile : MonoBehaviour
    {
        [SerializeField] float chaseSpeed;
        [SerializeField] float flyAwaySpeed;
        Transform player;
        Vector2 directionOfPlayer;
        Mover mover;
        Flipper flipper;
        Rotator rotator;
        bool isShot;
        bool determiningFlyAwayDirection;
        int randomHorizontal;
        int randomVertical;

        private void Start()
        {
            if (!GameObject.FindGameObjectWithTag("Player"))
                return;

            player = GameObject.FindGameObjectWithTag("Player").transform;
            mover = GetComponent<Mover>();
            flipper = GetComponent<Flipper>();
            rotator = GetComponent<Rotator>();
            flipper.ObjToFace = player;
        }

        private void Update()
        {
            if (!isShot && mover && player)
            mover.MoveTo(player, chaseSpeed);

            else
            {
                if (determiningFlyAwayDirection)
                {
                    randomHorizontal = (int)Random.Range(1, 3);
                    randomVertical = (int)Random.Range(1, 3);
                    determiningFlyAwayDirection = false;
                }
                    
                    switch (randomHorizontal)
                    {
                        case 1:
                            mover.MoveLeft(1);
                            break;
                        case 2:
                            mover.MoveRight(1);
                            break;
                    }

                    switch (randomVertical)
                    {
                        case 1:
                            mover.MoveUp(flyAwaySpeed);
                            break;
                        case 2:
                            mover.MoveDown(flyAwaySpeed);
                            break;
                    }

                if(rotator)
                rotator.Rotate(); 
            }
        }

        public void SetIsShot()
        {
            isShot = true;
            GetComponent<DamagePlayerCollider>().DisableCollider = true;
            determiningFlyAwayDirection = true;
        }
    }
}