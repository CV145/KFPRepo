using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// Component used by shootable enemies that has events that are called when shot.
/// </summary>
public class EnemyShotReceiver : ShotReceiver
{
    [SerializeField] ParticleEmitter bloodSplashEmitter;
    [SerializeField] ParticleEmitter bloodGushEmitter;
    [SerializeField] Health health;
    [SerializeField] bool reduceHealthWhenShot = true;
    [SerializeField] bool emitParticlesWhenShot = true;
    [SerializeField] float chanceOfBloodGush = 75f;

    public bool ReduceHealthWhenShot { get => reduceHealthWhenShot; set => reduceHealthWhenShot = value; }
    public bool EmitParticlesWhenShot { get => emitParticlesWhenShot; set => emitParticlesWhenShot = value; }

    /// <summary>
    /// Reduce health/emit particles when shot if bool is true.
    /// </summary>
    /// <param name="shotRaycast"></param>
    public void CauseDamage(int shotAttackPower, Vector2 shotPos)
    {
        if (ReduceHealthWhenShot)
            health.DecreaseHealth(shotAttackPower);

        if (EmitParticlesWhenShot)
        {
            bloodSplashEmitter.PlayParticles(shotPos);
            if (Random.Range(0, 100) >= chanceOfBloodGush)
            {
                bloodGushEmitter.PlayParticles(shotPos);
            }
        }
            
    }
}
