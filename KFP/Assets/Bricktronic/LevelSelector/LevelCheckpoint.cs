using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheckpoint : MonoBehaviour
{
    public int Level = 0;
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
        if (!LevelSystem.UnlockedLevels.Contains(Level))
        {
            Debug.Log("Saving checkpoint: " + Level);
            LevelSystem.UnlockedLevels.Add(Level);
            SaveSystem.SaveGame();
        } else
        {
            Debug.Log("Checkpoint: " + Level + " already obtained");
        }
    }
}
