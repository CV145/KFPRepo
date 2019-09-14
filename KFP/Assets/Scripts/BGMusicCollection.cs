using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for playing music in the background. Has methods for playing, stopping music etc
/// </summary>
public class BGMusicCollection : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] bool doNotPlaySongOnStart;
    [SerializeField] int songToPlayOnStart;
    AudioSource[] audioSources;
    AudioSource songCurrentlyPlaying;

    private void Start()
    {
        audioSources = new AudioSource[audioClips.Length];
        for(int index = 0; index < audioClips.Length; index++)
        {
            audioSources[index] = gameObject.AddComponent<AudioSource>();
           // print(audioSources[index].name);
            audioSources[index].clip = audioClips[index];                     
            audioSources[index].playOnAwake = false;
          //  print(index);
        }

        if (!doNotPlaySongOnStart)
        {
            Play(songToPlayOnStart);
        }
    }

    /// <summary>
    /// Play an audio clip using given index, stops previous song
    /// </summary>
    /// <param name="indexToPlay"></param>
    public void Play(int indexToPlay)
    {
        StopPlayingCurrentSong();
        audioSources[indexToPlay].Play();
    }

    /// <summary>
    /// Stops playing current song, if there is a song playing
    /// </summary>
    public void StopPlayingCurrentSong()
    {
        if (songCurrentlyPlaying != null)
        {
            songCurrentlyPlaying.Stop();
            songCurrentlyPlaying = null;
        }
    }
}
