using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

/// <summary>
/// Script for a game object with a cinematic to play.
/// </summary>
/// 
[RequireComponent(typeof(VideoPlayer))]
public class Cinematic : MonoBehaviour
{
    VideoPlayer videoPlayer;
    bool videoPlaying;
    [SerializeField] UnityEvent OnVideoFinishedPlaying;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        videoPlayer.loopPointReached += EndReached;
    }

     void EndReached(VideoPlayer vp)
    {
        OnVideoFinishedPlaying.Invoke();
        Time.timeScale = 1;
        Mover.gameIsPaused = false;
    }

    /// <summary>
    /// Plays the referenced cinematic.
    /// </summary>
    public void PlayCinematic()
    {
      //  print("play cinematic called");
        videoPlayer.Play();
        Time.timeScale = 0;
        Mover.gameIsPaused = true;
    }
}
