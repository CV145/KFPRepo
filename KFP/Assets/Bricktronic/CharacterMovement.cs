using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;

    public static bool Swiped = false;

    public float SWIPE_THRESHOLD = 50f;

    // Update is called once per frame
    void Update()
    {

        //PC controls
        if (Input.GetKey(KeyCode.W))
        {
            OnSwipeUp();
        }

        if (Input.GetKey(KeyCode.S))
        {
            OnSwipeDown();
        }

        if (Input.GetKey(KeyCode.A))
        {
            OnSwipeLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            OnSwipeRight();
        }
        //PC controls end

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Swiped = false;
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
        Swiped = true;
        GetComponent<Player>().Jump();
    }

    void OnSwipeDown()
    {
        Swiped = true;
        GetComponent<Player>().CurrentState = PlayerStates.SHOOT;
    }

    void OnSwipeLeft()
    {
        Swiped = true;
        if (GetComponent<Player>().flipper.FacingRight)
            GetComponent<Player>().Flip();

        GetComponent<Player>().CurrentState = PlayerStates.RUN;
    }

    void OnSwipeRight()
    {
        Swiped = true;
        if (!GetComponent<Player>().flipper.FacingRight)
            GetComponent<Player>().Flip();

        GetComponent<Player>().CurrentState = PlayerStates.RUN;
    }
}