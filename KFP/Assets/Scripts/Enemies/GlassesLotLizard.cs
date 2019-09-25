using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utilities;

    public class GlassesLotLizard : Enemy
    {
        public enum States
        {
            SHOOT,
            WALKTOPLAYER,
            MELEE,
        }
        Transform player;
        Flipper flipper;
        Mover mover;
        ProjectileShooter shooter;
        States currentState;
        [SerializeField] float moveSpeed;
        [SerializeField] float rangeToMeleePlayer;
        [SerializeField] float rangeToShootPlayer;
        [SerializeField] float intervalBetweenFiring;
        [SerializeField] float intervalBetweenMelees;
        [Header("Used to find exact time to fire")]
        [SerializeField] float shootAnimationTime = 0.8f; //0.8 best time so far
        float timeLeft = 0;
        float absoluteDistanceFromPlayer;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            flipper = GetComponent<Flipper>();
            mover = GetComponent<Mover>();
            shooter = GetComponent<ProjectileShooter>();
            flipper.ObjToFace = player;

            currentState = States.WALKTOPLAYER;
        }

        // Update is called once per frame
        void Update()
        {
            absoluteDistanceFromPlayer = UtilityMethods.GetAbsoluteDistance(transform, player);

            if (absoluteDistanceFromPlayer <= rangeToShootPlayer && shooter.CurrentAmmo > 0)
            {
                currentState = States.SHOOT;
                //print("within shooting range and has ammo");
            }
            else if (absoluteDistanceFromPlayer <= rangeToMeleePlayer)
            {
                currentState = States.MELEE;
            }
            else
            {
                if (timeLeft <= 0)
                currentState = States.WALKTOPLAYER;
            }

            switch (currentState)
            {
                case States.SHOOT:
                switch (Random.Range(0, 2))
                {
                    case 0:
                        DialogHandler.PlayEnemyDialog(this.gameObject, "Dialog/Lot Lizard/Snake/lot lizard snake attacking 1");
                        break;
                    case 1:
                        DialogHandler.PlayEnemyDialog(this.gameObject, "Dialog/Lot Lizard/Snake/Lotlizard snake attacking 1");
                        break;
                }
                Shoot();
                    break;
                case States.WALKTOPLAYER:
                    WalkToPlayer();
                    break;
                case States.MELEE:
                    MeleePlayer();
                    break;
            }            
        }

        private void Shoot()
        {
            if (timeLeft <= 0)
            {
                StopCoroutine("LoseTime");
                AnimController.SetTrigger("fireTrigger");
                StartCoroutine("FireProjectile");
                timeLeft = intervalBetweenFiring;
                StartCoroutine("LoseTime");
            }
        }

        private void WalkToPlayer()
        {
            if (flipper.FacingRight) mover.MoveRight(moveSpeed);
            else mover.MoveLeft(moveSpeed);
        }

        private void MeleePlayer()
        {
            if (timeLeft <= 0)
            {
            switch (Random.Range(0, 2))
            {
                case 0:
                    DialogHandler.PlayEnemyDialog(gameObject, "Dialog/Lot Lizard/Snake/lot lizard snake attacking 1");
                    break;

                case 1:
                    DialogHandler.PlayEnemyDialog(gameObject, "Dialog/Lot Lizard/Snake/Lotlizard snake attacking 1");
                    break;
            }
                StopCoroutine("LoseTime");
                AnimController.SetTrigger("meleeTrigger");
                timeLeft = intervalBetweenMelees;
                StartCoroutine("LoseTime");
            }
        }

        IEnumerator LoseTime()
        {
            while (true) 
            {
                yield return new WaitForSeconds(1);
                timeLeft--;
            }
        }

        //fire projectile at exact time in animation
        IEnumerator FireProjectile()
        {
                yield return new WaitForSeconds(shootAnimationTime);
                shooter.Fire();
        }
}