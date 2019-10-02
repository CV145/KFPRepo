using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] string newGameScene;
    [SerializeField] string testScene;

    public void Continue()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void NewGame()
    {
        LevelSystem.LevelDifficulty = 1;
        SceneManager.LoadScene(newGameScene);
    }

    public void Testing()
    {
        LevelSystem.LevelDifficulty = 5;
        SceneManager.LoadScene(testScene);
    }
}
