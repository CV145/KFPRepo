using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
GameObject: Any object that can be destroyed by player bullets
 */
 [RequireComponent(typeof(BoxCollider2D))]
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
    protected void DisableObject()
    {
        deathResponses.Invoke();
        transform.parent.gameObject.SetActive(false);
    }

    //used to instantiate an object
    public void SpawnObject(GameObject objToSpawn)
    {
        print("SpawnObject called");
        Instantiate(objToSpawn, this.transform.position, Quaternion.identity);
    }
}
