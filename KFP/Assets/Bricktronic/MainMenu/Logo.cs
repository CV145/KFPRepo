using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    Vector3 OriginalRotation;
    public bool CanSpin;
    float SpinInertia;
    bool CanDecrease;

    private void Start()
    {
        OriginalRotation = transform.rotation.eulerAngles;

        if(CanSpin)
        GetComponentInChildren<Button>().onClick.AddListener(Spin);
    }

    private void Spin()
    {
        StartCoroutine(SpinUp(20 + SpinInertia*2));
    }

    IEnumerator SpinUp(float goal)
    {
        yield return new WaitForFixedUpdate();
        SpinInertia+=2;
        if (SpinInertia < goal)
        {
            CanDecrease = false;
            StartCoroutine(SpinUp(goal));
        } else
        {
            CanDecrease = true;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0, 0, Mathf.Sin(Time.time * 2) + (1 * SpinInertia)),0.9f);

        if (CanDecrease)
        {
            if (SpinInertia > 0)
            {
                SpinInertia -= SpinInertia*0.05f;
            }
            else
            {
                SpinInertia = 0;
            }
        }
    }
}
