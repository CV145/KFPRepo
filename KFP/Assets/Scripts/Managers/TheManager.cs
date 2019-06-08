using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(UiManager))]

[System.Serializable]
public class TheManager : MonoBehaviour
{
    private static GameManager _gameManager;
    public static GameManager Game
    {
        get { return _gameManager; }
    }

    private static UiManager _uiManager;
    public static UiManager Ui
    {
        get { return _uiManager; }
    }

    void Awake()
    {

        _gameManager = GetComponent<GameManager>();

        _uiManager = GetComponent<UiManager>();

        

        DontDestroyOnLoad(gameObject);
    }

}
