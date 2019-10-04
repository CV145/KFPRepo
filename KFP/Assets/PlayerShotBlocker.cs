using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to stop player shooting when clicking on something like a UI button
/// </summary>
public class PlayerShotBlocker : MonoBehaviour
{
    public static bool stopShooting;

    private void OnPointerDown()
    {
        print("mouse down");
        stopShooting = true;
    }

    private void OnPointerUp()
    {
        stopShooting = false;
    }
}
