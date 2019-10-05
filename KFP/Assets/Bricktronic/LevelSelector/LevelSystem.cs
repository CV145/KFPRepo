using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public static List<int> UnlockedLevels = new List<int>();
    public static int LevelDifficulty;
    public static string currentLevel;

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
