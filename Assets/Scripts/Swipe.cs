using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum SwipeDirection
{ 
    Right,
    Left,
    Up,
    Down,
    Tap
}

public class Swipe : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SwipeInputText;
    [SerializeField] GameObject Player;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    // public int swipeDirection = 0; // 1 Right, 2 Left, 3 Up, 4 Down
    // public SwipeDirection swipeDirection;
    Vector2 swipeDelta = Vector2.zero;


    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            Touch touch = Input.GetTouch(0);
            startTouchPosition = touch.position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Touch touch = Input.GetTouch(0);
            endTouchPosition = touch.position;

            CheckSwipe();
        }

    }

    void CheckSwipe() // 1 R, 2 L, 3 U, 4 D, 5 Tap
    {
        bool checkLeft = PointOnLeft(startTouchPosition,endTouchPosition,swipeDelta);

        if ((startTouchPosition.x < endTouchPosition.x) && !checkLeft)
        {
            SwipeInputText.text = "Swipe Right";
            Player.GetComponent<PlayerScript>().Attack(SwipeDirection.Right);
        }

        else if ((startTouchPosition.x > endTouchPosition.x) && checkLeft)
        {
            SwipeInputText.text = "Swipe Left";
            Player.GetComponent<PlayerScript>().Attack(SwipeDirection.Left);
        }

        else if ((startTouchPosition.y < endTouchPosition.y))
        {
            SwipeInputText.text = "Swipe Up";
            Player.GetComponent<PlayerScript>().Attack(SwipeDirection.Up);
        }

        else if ((startTouchPosition.y > endTouchPosition.y))
        {
            SwipeInputText.text = "Swipe Down"; 
            Player.GetComponent<PlayerScript>().Attack(SwipeDirection.Down);
        }

        else if ((startTouchPosition.x + endTouchPosition.x < 40 && startTouchPosition.x - endTouchPosition.x > 0) && (startTouchPosition.y + endTouchPosition.y < 40 && startTouchPosition.y - endTouchPosition.y > 0))
        {
            SwipeInputText.text = "Tap";
            Player.GetComponent<PlayerScript>().Attack(SwipeDirection.Tap);
        }
    }
    private bool PointOnLeft(Vector2 point1, Vector2 point2, Vector2 point3)
    {
        return (point2.x - point1.x) * (point3.y - point1.y) - (point2.y - point1.y) * (point3.x - point1.x) > 0;
    }
}
