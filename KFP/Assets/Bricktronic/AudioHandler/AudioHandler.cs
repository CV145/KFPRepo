using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour {
    public static List<AudioSource> ReplaceOnName = new List<AudioSource>();
    public static GameObject PlayAudio(string ClipPath, Vector3 Position, float Volume = 1, float Pitch = 1, GameObject Parent = null, bool NoOverlap = false)
    {
        GameObject AudioContainer = new GameObject();
        AudioSource Source = AudioContainer.AddComponent<AudioSource>();
        AudioClip Clip = Resources.Load(ClipPath) as AudioClip;
        if (Parent != null)
        {
            AudioContainer.transform.position = Parent.transform.position;
            Source.spatialBlend = 1;
        } else
        {
            Source.spatialBlend = 0;
        }
        Source.maxDistance = 1.0f;
        Source.pitch = Pitch;
        Source.volume = Volume;
        Source.clip = Clip;
        Source.transform.position = Position;
        Source.Play();

        Source.name = ClipPath;

        List<AudioSource> TBR = new List<AudioSource>();

        if (NoOverlap)
        {
            foreach (AudioSource SRC in ReplaceOnName)
            {
                if (SRC == null)
                {
                    TBR.Add(SRC);
                    continue;
                }
                if (SRC.name == Source.name)
                {
                    SRC.Stop();
                }
            }
            ReplaceOnName.Add(Source);
        }

            foreach(AudioSource SRC in TBR)
            {
                ReplaceOnName.Remove(SRC);
            }

        DontDestroyOnLoad(Source);
        Destroy(AudioContainer, Clip.length);

        return AudioContainer;
    }
}
