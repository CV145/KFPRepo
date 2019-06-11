using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//used on any item that is meant to go straight to the player
[RequireComponent(typeof(BoxCollider2D))]
public class ItemChasePlayer : AIMovement
{
    GameObject player;
    [SerializeField] UnityEvent onCollidePlayer;

    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected new void Update()
    {
        if (AllowMovement)
        {
            ChasePlayer();
        }
    }

    //go after the player from the current position
    private void ChasePlayer()
    {
        Vector2 playerPosition = player.transform.position;
        //print("Player position: " + playerPosition.ToString());

        Vector2 direction = new Vector2(
            playerPosition.x - this.transform.position.x,
            playerPosition.y - this.transform.position.y);
        //print("Direction: " + direction.ToString());

        Vector2 newPosition = new Vector2(
            direction.x * movementSpeed * Time.deltaTime,
            direction.y * movementSpeed * Time.deltaTime);
        //print("New position: " + newPosition.ToString());

        this.transform.Translate(newPosition);
    }

    //invoke an event then destroy self
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onCollidePlayer.Invoke();
            Destroy(this.gameObject);
        }
    }
}
