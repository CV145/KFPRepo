using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static List<int> UnlockedLevels = new List<int>();
    private void Start()
    {
        SaveSystem.LoadGame();

        foreach(int Unlock in UnlockedLevels)
        {
            Debug.Log(Unlock + " Unlocked");
        }
    }

    public static void AddLevel(int l)
    {
        if (!UnlockedLevels.Contains(l))
        {
            UnlockedLevels.Add(l);
            Debug.Log("Added level: " + l);
        } else
        {
            Debug.Log("Already unlocked level" + l);
        }
    }

    public static void ClearSaves()
    {
        UnlockedLevels.Clear();
        SaveSystem.SaveGame();
    }
}
