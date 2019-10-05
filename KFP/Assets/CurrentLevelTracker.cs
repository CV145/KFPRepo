using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentLevelTracker : MonoBehaviour
{
    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(LevelSystem.currentLevel);
    }
}
