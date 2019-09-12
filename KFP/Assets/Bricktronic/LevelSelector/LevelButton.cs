using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int Level = 0;
    public string SceneName = "Level1";
    private void Start()
    {
        if (LevelSystem.UnlockedLevels.Contains(Level))
        {
            //level exists
        } else
        {
            //level does not exist;
            this.gameObject.SetActive(false);
        }
        this.GetComponent<Button>().onClick.AddListener(LoadLevel);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneName);
    }
}
