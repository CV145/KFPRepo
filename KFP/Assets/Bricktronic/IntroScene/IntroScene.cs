using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    //Simply waits a few seconds before loading the main scene.
    void Start()
    {
        StartCoroutine(WaitScene());
    }
    public IEnumerator WaitScene()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("MainMenu");
    }
}
