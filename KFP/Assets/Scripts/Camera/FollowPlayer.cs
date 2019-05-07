using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script follows the player until a timeline is triggered
public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] bool focusOnPlayer;
    CameraTimelines cameraTimelines;

    private void Start()
    {
        cameraTimelines = GetComponent<CameraTimelines>();
    }

    private void Update()
    {
        moveToPlayer();
    }

    //always follow the player
    private void moveToPlayer()
    {
        if (focusOnPlayer)
        {
            transform.position = new Vector3(playerPosition.position.x + 13, transform.position.y, -10f);
        }
    }
}
