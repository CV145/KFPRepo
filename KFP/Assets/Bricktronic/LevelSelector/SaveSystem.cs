using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

[System.Serializable]
public class SaveSystem : MonoBehaviour
{
    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveGame.KFP");

        SaveData SD = new SaveData()
        {
            Levels = LevelSystem.UnlockedLevels,
            Pesos = PesoSystem.Pesos,
        };

        bf.Serialize(file, SD);
        file.Close();
    }

    public static void LoadGame()
    {
        if (!File.Exists(Application.persistentDataPath + "/SaveGame.KFP"))
        {
            Debug.Log("No save file found. This may be the first time starting up the app.");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/SaveGame.KFP", FileMode.Open);
        SaveData SD = (SaveData)bf.Deserialize(file);
        LevelSystem.UnlockedLevels = SD.Levels;
        PesoSystem.Pesos = SD.Pesos;
        file.Close();
    }
}

[System.Serializable]
public struct SaveData
{
    public List<int> Levels;
    public int Pesos;
}
