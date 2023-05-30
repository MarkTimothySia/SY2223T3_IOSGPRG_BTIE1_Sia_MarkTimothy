using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] List<Sprite> Arrows;
    [SerializeField] TextMeshProUGUI SwipeInputText;

    private bool OnPress = false;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private Vector2 mouseStartPos;
    private Vector2 mouseEndPos;

    private void Update()
    { 
        // Not sure why does not work, time to Yeet
        for (int i = 0; i < Input.touchCount; ++i)
        {
            // Records touch
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0) )
            {
                startTouchPosition = Input.GetTouch(0).position;
                mouseStartPos = Input.mousePosition; 
                OnPress = true;

            }

            if ( (OnPress || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) )
            {
                endTouchPosition = Input.GetTouch(0).position;
                mouseEndPos = Input.mousePosition;

                if (endTouchPosition.x < startTouchPosition.x || mouseEndPos.x < mouseStartPos.x)
                {
                    // Left swipe 
                    LeftSwipe();
                }


                if (endTouchPosition.x > startTouchPosition.x || mouseEndPos.x > mouseStartPos.x) 
                {
                    // Right Swipe
                    RightSwipe();
                }


                if (endTouchPosition.y < startTouchPosition.y || mouseEndPos.y < mouseStartPos.y) 
                {
                    // Up swipe
                    UpSwipe();
                }


                if (endTouchPosition.y > startTouchPosition.y || mouseEndPos.y > mouseStartPos.y)
                {
                    // Down Swipe
                    DownSwipe();
                }

            } 
        }

        void RightSwipe()
        {
            Debug.Log("Swipe Right");
            SwipeInputText.text = "Swipe Right";

        }

        void LeftSwipe()
        {
            Debug.Log("Swipe Left");
            SwipeInputText.text = "Swipe Left";
        }

        void UpSwipe()
        {
            Debug.Log("Swipe Up");
            SwipeInputText.text = "Swipe Up";
        }

        void DownSwipe()
        {
            Debug.Log("Swipe Down");
            SwipeInputText.text = "Swipe Down";
        }
    }
}
