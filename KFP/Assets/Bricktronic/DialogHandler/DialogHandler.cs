using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{
    public static GameObject KFPAudio = null;
    public static GameObject EnemyAudio = null;

    public static GameObject AttachedEnemy = null;

    public static GameObject AttachedKFP = null;

    public static void PlayEnemyDialog(GameObject GO, string path)
    {
        if (EnemyAudio == null)
        {
            AttachedEnemy = GO;
            EnemyAudio = AudioHandler.PlayAudio(path, Vector3.zero, 1, 1, null, true);
        }
    }

    public static void PlayKFPDialog(GameObject GO, string path)
    {
        if (KFPAudio == null)
        {
            AttachedKFP = GO;
            KFPAudio = AudioHandler.PlayAudio(path, Vector3.zero, 1, 1, null, true);
        }
    }

    public static void CheckDeath(GameObject GO)
    {
        if (AttachedEnemy == GO)
        {
            if (EnemyAudio != null)
            {
                if (EnemyAudio.GetComponent<AudioSource>().isPlaying)
                {
                    EnemyAudio.GetComponent<AudioSource>().Stop();
                }
                Destroy(EnemyAudio);
            }
        }

        if (AttachedKFP == GO)
        {
            if (KFPAudio != null)
            {
                if (KFPAudio.GetComponent<AudioSource>().isPlaying)
                {
                    KFPAudio.GetComponent<AudioSource>().Stop();
                }
                Destroy(KFPAudio);
            }
        }
    }
}
