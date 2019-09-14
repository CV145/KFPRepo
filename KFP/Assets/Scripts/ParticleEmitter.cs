using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Takes in a particle system and has methods for playing and positioning it.
/// </summary>
public class ParticleEmitter : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] bool makeCopiesOfParticleSystem = false;
    [Header("Set to 1 to not randomize")]
    [SerializeField] float randomizeVelocityMin = 1f, randomizeVelocityMax = 1f;

    /// <summary>
    /// Plays the stored ParticleSystem and emits them in the given position.
    /// </summary>
    /// <param name="positionToEmit"></param>
    public void PlayParticles(Vector2 positionToEmit)
    {
        ParticleSystem.VelocityOverLifetimeModule velocityModule;
        if (!makeCopiesOfParticleSystem)
        {
            particleSystem.gameObject.transform.position = positionToEmit;
            velocityModule = particleSystem.velocityOverLifetime;
            velocityModule.xMultiplier = Random.Range(randomizeVelocityMin, randomizeVelocityMax);
            velocityModule.yMultiplier = Random.Range(randomizeVelocityMin, randomizeVelocityMax);
            particleSystem.Play();
        }
        else
        {
            ParticleSystem newSystem = Instantiate(particleSystem);
            newSystem.gameObject.transform.parent = this.transform.parent;
            newSystem.gameObject.transform.position = positionToEmit;
            velocityModule = newSystem.velocityOverLifetime;
            velocityModule.xMultiplier = Random.Range(randomizeVelocityMin, randomizeVelocityMax);
            velocityModule.yMultiplier = Random.Range(randomizeVelocityMin, randomizeVelocityMax);
            newSystem.Play();
        }
    }

    /// <summary>
    /// Play particles at the game object's position.
    /// </summary>
    public void InstantiateParticles()
    {
        //ParticleSystem.VelocityOverLifetimeModule velocityModule;
            ParticleSystem newSystem = Instantiate(particleSystem);
        newSystem.gameObject.transform.position = this.transform.position;
            //velocityModule = newSystem.velocityOverLifetime;
            //velocityModule.xMultiplier = Random.Range(randomizeVelocityMin, randomizeVelocityMax);
            //velocityModule.yMultiplier = Random.Range(randomizeVelocityMin, randomizeVelocityMax);
            newSystem.Play();

        float totalDuration = newSystem.main.duration + newSystem.main.startLifetimeMultiplier;
        newSystem.GetComponent<Destroyer>().DestroySelf(totalDuration);
    }
}
