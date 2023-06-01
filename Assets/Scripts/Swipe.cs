using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SwipeInputText;

    private int minSwipeDistance = 50;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private int swipeDirection = 0;
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


            checkSwipe();
        }

    }

    void checkSwipe() // 1 R, 2 L, 3 U, 4 D
    {
        
        bool checkLeft = PointOnLeft(startTouchPosition,endTouchPosition,swipeDelta);


        if ((startTouchPosition.x < endTouchPosition.x) && !checkLeft) 
        {
            SwipeInputText.text = "Swipe Right";
            swipeDirection = 1;

        }
        else if ((startTouchPosition.x > endTouchPosition.x) &&  checkLeft)
        {
            SwipeInputText.text = "Swipe Left";

            swipeDirection = 2;
        }

        else if ((startTouchPosition.y < endTouchPosition.y) )
        {
            SwipeInputText.text = "Swipe Up";

            swipeDirection = 3;
        }
        else if ((startTouchPosition.y > endTouchPosition.y))
        {
            SwipeInputText.text = "Swipe Down";

            swipeDirection = 4;
        }

    }
    private bool PointOnLeft(Vector2 point1, Vector2 point2, Vector2 point3)
    {
        return (point2.x - point1.x) * (point3.y - point1.y) - (point2.y - point1.y) * (point3.x - point1.x) > 0;
    }
}
