using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
GameObject: Any object that can be destroyed by player bullets
- Stores a hits variable and has a TakeDamage method that, when called, reduces hits by 1. Once those hits reach 0 an event can be raised, such as spawning an explosion or playing an animation, apart from disabling the object. */

public class DestructibleObject : MonoBehaviour
{
    [SerializeField] int hits;
    [SerializeField] UnityEvent deathResponses;

    //reduce hits by 1 and check whether to destroy object
    public void TakeDamage()
    {
        hits--;
        if (hits <= 0) { DisableObject(); }
    }

    //invoke events (play an animation, explode, etc) before destroying the object
    private void DisableObject()
    {
        deathResponses.Invoke();
        gameObject.SetActive(false);
    }
}
