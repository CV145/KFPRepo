using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//enables all selected enemies in enemiesToEnable[]
public class EnableObjectsEvent : TriggerEvent
{
    [Header("somewhere to enable enemies")]
    [Header("Call InvokeResponses from")]
    [SerializeField] GameObject[] objectsToEnable;
    [Header("What to do beside spawning enemies")]
    [SerializeField] UnityEvent spawnEvent;

    private new void Start()
    {
        base.Start();
        spawnEvent.AddListener(enableEnemies);
    }

    private void enableEnemies()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }

    override
    public void InvokeResponses()
    {
        spawnEvent.Invoke();
    }
}
