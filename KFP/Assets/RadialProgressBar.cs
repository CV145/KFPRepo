using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for a radial progress bar.
/// </summary>
public class RadialProgressBar : MonoBehaviour
{
    public Image LoadingBar;
    float currentValue;

    public float CurrentValue { get => currentValue; }

    /// <summary>
    /// Increase the value of the progress bar by a given speed.
    /// </summary>
    public void IncreaseValue(float speed)
    {
        if (CurrentValue < 100)
        {
            currentValue += speed * Time.deltaTime;
        }
        else
        {
        }

        LoadingBar.fillAmount = CurrentValue / 100;
    }

    /// <summary>
    /// Cancel progress bar value back to 0.
    /// </summary>
    public void CancelProgress()
    {
        currentValue = 0;
    }
}
