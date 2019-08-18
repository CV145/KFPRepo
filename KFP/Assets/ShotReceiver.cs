using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// Component used by shootable objects that has events that are called when shot.
/// </summary>
public class ShotReceiver : MonoBehaviour
{
    [Header("Used for changes in behavior")]
    [SerializeField] UnityEvent reactionWhenShot;
    [SerializeField] ParticleEmitter bloodSplashEmitter;
    [SerializeField] ParticleEmitter bloodGushEmitter;
    [SerializeField] Health health;
    [SerializeField] bool reduceHealthWhenShot = true;
    [SerializeField] bool emitParticlesWhenShot = true;
    [SerializeField] float chanceOfBloodGush = 75f;

    /// <summary>
    /// Invoke an event, if any, and reduce health/emit particles when shot if bool is true.
    /// </summary>
    /// <param name="shotRaycast"></param>
    public void ReceiveShot(int shotAttackPower, Vector2 shotPos)
    {
        reactionWhenShot.Invoke();

        if (reduceHealthWhenShot)
            health.DecreaseHealth(shotAttackPower);

        if (emitParticlesWhenShot)
        {
            bloodSplashEmitter.PlayParticles(shotPos);
            if (Random.Range(0, 100) >= chanceOfBloodGush)
            {
                bloodGushEmitter.PlayParticles(shotPos);
            }
        }
            
    }
}
