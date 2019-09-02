using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mover that moves an object back and forth.
/// </summary>
public class BackForthMover : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] float horizontalMoveDistance;
    [SerializeField] float verticalMoveDistance;
    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(startPos.x + Mathf.PingPong(Time.time * speed, horizontalMoveDistance), startPos.y + Mathf.PingPong(Time.time * speed, verticalMoveDistance));
    }
}
