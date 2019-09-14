using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI for ammo. Stores a stack of bullet image game objects. A list is initialized in the inspector.
/// The PlayerShooter component looks for this script and calls methods from it to update its information.
/// </summary>
public class AmmoUI : MonoBehaviour
{
    [SerializeField] List<GameObject> bulletImages;
    Stack<GameObject> imageStack;

    private void Start()
    {
        imageStack = new Stack<GameObject>(bulletImages.Count);
        InitializeStack();
    }

    /// <summary>
    /// "Reload" method brings back all bullet images.
    /// </summary>
    public void InitializeStack()
    {
        foreach (GameObject image in bulletImages)
        {
            imageStack.Push(image);
            image.SetActive(true);
            image.GetComponent<BulletHUDImage>().DeactivateCountdown();
            image.GetComponent<BulletHUDImage>().Reset();
        }
        //print("initalized stack");
    }

    /// <summary>
    /// "Shoot" method releases a bullet image.
    /// </summary>
    public void ReleaseBullet()
    {
        //print("peeking: " + imageStack.Peek().ToString());
        imageStack.Peek().GetComponent<BulletHUDImage>().SetIsFlying();
        imageStack.Pop();
    }
}
