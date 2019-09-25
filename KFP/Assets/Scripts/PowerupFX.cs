using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collection of methods for powerup effects
/// </summary>
public class PowerupFX : MonoBehaviour
{

    [SerializeField] float sublimeBulletTimeLength = 5f;
    [SerializeField] float sublimeBulletTimeSpeedMultiplier = 0.5f;
    [SerializeField] float quadruplePupilTimeLength = 5f;
    [SerializeField] float bodySlamJamTimeLength = 5f;
    [SerializeField] float pushKickTrickTimeLength = 1f;
    [SerializeField] float pushKickTrickPower = 0.4f;

    public void PushKickTrick()
    {
        EnemyStatusFX[] enemies = FindObjectsOfType<EnemyStatusFX>();
        foreach (EnemyStatusFX enemy in enemies)
        {
            enemy.TriggerPushEffect(pushKickTrickPower, pushKickTrickTimeLength);
        }
    }

    public void BodySlamJam()
    {

        EnemyStatusFX[] enemies = FindObjectsOfType<EnemyStatusFX>();
        foreach (EnemyStatusFX enemy in enemies)
        {
            enemy.TriggerFreezeEffect(bodySlamJamTimeLength);
        }
    }

    public void QuadruplePupil()
    {
        // coroutine
        // while true, keep ammo infinite
        // HUD should not remove bullets
    }

    public void SublimeBulletTime()
    {
        EnemyStatusFX[] enemies = FindObjectsOfType<EnemyStatusFX>();
        foreach (EnemyStatusFX enemy in enemies)
        {
            enemy.TriggerSlowdownEffect(sublimeBulletTimeSpeedMultiplier,
                sublimeBulletTimeLength);
        }
    }
}
