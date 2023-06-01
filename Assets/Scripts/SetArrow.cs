using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArrow : MonoBehaviour
{
    [SerializeField] Sprite[] ArrowSprites;
    [SerializeField] GameObject Enemy;

    Color red = Color.red;
    Color green = Color.green;

    public int setArrowToInput;
    public int RNGArrowChoice;

    private bool isReverse;


    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = null;
        deployArrow();
    }

    void deployArrow()
    {
        // RNG if normal, Reverse, Moving, moving Reverse

        setArrowToInput = Random.Range(1, 4);

        RNGArrowChoice = Random.Range(0, 3);

        this.GetComponent<SpriteRenderer>().color = green;

        UnityEngine.Debug.Log(RNGArrowChoice);


        switch (RNGArrowChoice)
        {
            case 0:
                // Normal

                this.GetComponent<SpriteRenderer>().sprite = ArrowSprites[setArrowToInput];
                break;

            case 1:
                // Reverse

                isReverse = true;
                this.GetComponent<SpriteRenderer>().color = red;
                this.GetComponent<SpriteRenderer>().sprite = ArrowSprites[setArrowToInput];
                break;

            case 2:
                // Moving

                checkInRangeArrow(Enemy.GetComponent<EnemyScript>().inRange);
                break;

            case 3:
                // Reverse + Moving

                isReverse = true;
                this.GetComponent<SpriteRenderer>().color = red;
                checkInRangeArrow(Enemy.GetComponent<EnemyScript>().inRange);
                break;
        }

    }

    void checkInRangeArrow(bool offRange)
    {
        if (offRange)
        {
            StartCoroutine(SpinArrow());
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = ArrowSprites[setArrowToInput];
        }
    }

    IEnumerator SpinArrow()
    {
        int randomArrow = Random.Range(1, 4);
        this.GetComponent<SpriteRenderer>().sprite = ArrowSprites[randomArrow];
  
        yield return new WaitForSeconds(1);

        StartCoroutine(SpinArrow());
    }
}
