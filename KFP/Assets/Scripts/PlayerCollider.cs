using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for collisions against player
public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //TheManager.Camera.glitch();
        }
    }
}
