using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemMechanics : MonoBehaviour
{
    public void LoadAtCheckpoint(int level,string scene)
    {
        SceneManager.LoadScene(scene);
        foreach (GameObject Checkpoint in LevelCheckpoint.Checkpoints)
        {
            if (Checkpoint.GetComponent<LevelCheckpoint>().Level == level)
            {
                GameObject.Find("Player Varient").transform.position = Checkpoint.transform.position;
                Debug.Log("Attempting to spawn player at: " + level);
            }
        }
    }
}
