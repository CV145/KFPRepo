using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// A collection of cinematics. Can be played, then rewinded.
/// </summary>

public class Cinematics : MonoBehaviour
{
    [SerializeField] Cinematic[] cinematicsList;
    [SerializeField] GameObject[] objectsToDisableWhilePlaying;
    Cinematic activeCinematic;

    bool SpawnedCinematic;

    /// <summary>
    /// Plays a cinematic according to given name.
    /// </summary>
    /// <param name="cinematicName"></param>
    public void Play(int cinematicIndex)
    {
        activeCinematic = cinematicsList[cinematicIndex];
        activeCinematic.gameObject.SetActive(true);
        DisableObjects(); //not playing first time?
        activeCinematic.PlayCinematic();
    }

    /// <summary>
    /// Disables cinematic and re-enables objects in objectsToDisable list.
    /// </summary>
    public void StopPlaying()
    {
        activeCinematic.gameObject.SetActive(false);
        EnableObjects();

        if (!SpawnedCinematic)
        {
            GameObject ZoomTrigger = Instantiate(Resources.Load("ZoomTrigger") as GameObject);
            ZoomTrigger.transform.position = Player.PlayerObject.transform.position + new Vector3(5, 0);
            SpawnedCinematic = true;
        }
    }

    /// <summary>
    /// Disable objects in disable objects list.
    /// </summary>
    private void DisableObjects()
    {
        //print("disable objects called");
        foreach (GameObject obj in objectsToDisableWhilePlaying)
        {
            obj.SetActive(false);
        }
    }

    /// <summary>
    /// Enable objects in enable objects list.
    /// </summary>
    private void EnableObjects()
    {
        foreach (GameObject obj in objectsToDisableWhilePlaying)
        {
            obj.SetActive(true);
        }
    }
}
