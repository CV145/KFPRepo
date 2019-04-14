using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform playerPosition;


    private void Update()
    {
        moveToPlayer();
    }

    //always follow the player
    private void moveToPlayer()
    {
        transform.position = new Vector3(playerPosition.position.x + 13, transform.position.y, -10f);
    }
}
