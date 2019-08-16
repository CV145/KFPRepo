using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

/// <summary>
/// Makes the glitch effect.
/// </summary>
public class GlitchEffectMaker : MonoBehaviour
{
    //I changed the CameraManager to focus on just the glitching so it can be attached to the player and have its
    //variables changed in the inspector

    Camera MainCamera;
    [SerializeField] float startTime, glitchTime;
    [SerializeField] float intensity, verticalJump, horizontalShake, colorDrift;

    private void Start()
    {
        MainCamera = Camera.main;
    }

    /// <summary>
    /// Create the glitch effect.
    /// </summary>
    public void MakeGlitch() {
        StartCoroutine(OnHitCameraShake());
    }

    public IEnumerator OnHitCameraShake()
    {
        
        DigitalGlitch digitalGlitch = MainCamera.GetComponentInChildren<Kino.DigitalGlitch>();
        AnalogGlitch analogGlitch = MainCamera.GetComponentInChildren<Kino.AnalogGlitch>();


        yield return new WaitForSeconds(startTime);
        digitalGlitch.intensity = intensity;
        analogGlitch.verticalJump = verticalJump;
        analogGlitch.horizontalShake = horizontalShake;
        analogGlitch.colorDrift = colorDrift;


        //yield return new WaitForSeconds(.5f);
        //digitalGlitch.intensity = 0.3f;
        //analogGlitch.verticalJump = 0.3f;
        //analogGlitch.horizontalShake = .3f;
        //analogGlitch.colorDrift = .3f;



        yield return new WaitForSeconds(glitchTime);
        digitalGlitch.intensity = 0f;
        analogGlitch.verticalJump = 0.0f;
        analogGlitch.horizontalShake = .0f;
        analogGlitch.colorDrift = .0f;
        StopCoroutine(OnHitCameraShake());
    }
}
