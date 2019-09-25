using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script with methods for changing scenes. UI buttons only.
/// </summary>
public class MenuSceneChanger : MonoBehaviour
{
    public void ChangeScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
