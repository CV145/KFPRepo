using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheckpoint : MonoBehaviour
{
    public int newLevelToUnlock = 0;
    public static bool InitializedSave = false;
    public static List<GameObject> Checkpoints = new List<GameObject>();

    private void Start()
    {
        if (!InitializedSave)
        {
            InitializedSave = true;
            SaveSystem.LoadGame();
            Debug.Log("Attempted loading default game save");
        }
        Checkpoints.Add(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!LevelSystem.UnlockedLevels.Contains(newLevelToUnlock))
            {
                Debug.Log("Saving checkpoint: " + newLevelToUnlock);
                LevelSystem.UnlockedLevels.Add(newLevelToUnlock);
                SaveSystem.SaveGame();
            }
            else
            {
                Debug.Log("Checkpoint: " + newLevelToUnlock + " already obtained");
            }
        } 
    }
}
