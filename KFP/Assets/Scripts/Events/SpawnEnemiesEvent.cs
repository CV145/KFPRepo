using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//enables all selected enemies in enemiesToEnable[]
public class SpawnEnemiesEvent : TriggerEvent
{
    [SerializeField] GameObject[] enemiesToEnable;
    [Header("What to do beside spawning enemies")]
    [SerializeField] UnityEvent spawnEvent;

    private new void Start()
    {
        base.Start();
        spawnEvent.AddListener(enableEnemies);
    }

    private void enableEnemies()
    {
        foreach (GameObject enemy in enemiesToEnable)
        {
            enemy.SetActive(true);
        }
    }

    override
    public void InvokeResponses()
    {
        spawnEvent.Invoke();
    }
}
