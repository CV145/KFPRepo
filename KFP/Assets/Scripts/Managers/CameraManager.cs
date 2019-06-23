using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class CameraManager : MonoBehaviour
{
    public Camera MainCamera;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void glitch() {
        StartCoroutine(OnHitCameraShake());
    }

    public IEnumerator OnHitCameraShake()
    {
        
        DigitalGlitch digitalGlitch = MainCamera.GetComponentInChildren<Kino.DigitalGlitch>();
        AnalogGlitch analogGlitch = MainCamera.GetComponentInChildren<Kino.AnalogGlitch>();


        yield return new WaitForSeconds(.1f);
        digitalGlitch.intensity = 0.2f;
        analogGlitch.verticalJump = 0.2f;
        analogGlitch.horizontalShake = .2f;
        analogGlitch.colorDrift = .2f;


        yield return new WaitForSeconds(.5f);
        digitalGlitch.intensity = 0.3f;
        analogGlitch.verticalJump = 0.3f;
        analogGlitch.horizontalShake = .3f;
        analogGlitch.colorDrift = .3f;



        yield return new WaitForSeconds(.5f);
        digitalGlitch.intensity = 0f;
        analogGlitch.verticalJump = 0.0f;
        analogGlitch.horizontalShake = .0f;
        analogGlitch.colorDrift = .0f;
        StopCoroutine(OnHitCameraShake());
    }
}
