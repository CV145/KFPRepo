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
        SceneManager.LoadScene(newGameScene);
    }

    public void Testing()
    {
        SceneManager.LoadScene(testScene);
    }
}
