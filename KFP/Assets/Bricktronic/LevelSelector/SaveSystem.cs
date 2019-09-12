using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]
public class SaveSystem : MonoBehaviour
{

    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveGame.KFP");
        bf.Serialize(file, LevelSystem.UnlockedLevels);
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
        LevelSystem.UnlockedLevels = (List<int>)bf.Deserialize(file);
        file.Close();
    }
}
