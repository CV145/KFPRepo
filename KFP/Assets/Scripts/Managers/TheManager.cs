using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(UiManager))]
[RequireComponent(typeof (CameraManager))]

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

    private static CameraManager _cameraManager;
    public static CameraManager Camera
    {
        get { return _cameraManager; }

    }
    void Awake()
    {

        _gameManager = GetComponent<GameManager>();

        _uiManager = GetComponent<UiManager>();

        _cameraManager = GetComponent<CameraManager>();

        DontDestroyOnLoad(gameObject);
    }

}
