using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//event that, when called, checks whether certain enemies are defeated
public class DefeatEnemiesEvent : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesToDefeat;
    [SerializeField] UnityEvent onAllEnemiesDefeated;
    [SerializeField] bool eventIsRunning;
    public bool EventIsRunning { get => eventIsRunning; set => eventIsRunning = value;  }

    private void Update()
    {
        if (eventIsRunning)
        {
            CheckEnemiesAreDefeated();
        }
    }

    //check if all enemiesToDefeat are disabled
    private void CheckEnemiesAreDefeated()
    {
        int defeatCount = 0;
        foreach (GameObject enemy in enemiesToDefeat)
        {
            if (!enemy.activeInHierarchy)
            {
                defeatCount++;
            }
        }
        if (defeatCount == enemiesToDefeat.Length)
        {
            onAllEnemiesDefeated.Invoke();
        }
    }
}
