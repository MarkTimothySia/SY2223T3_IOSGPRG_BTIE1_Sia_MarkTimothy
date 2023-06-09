using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArrow : MonoBehaviour
{
    [SerializeField] Sprite[] ArrowSprites;
    [SerializeField] GameObject Enemy;

    Color red = Color.red;
    Color green = Color.green;
    Color yellow = Color.yellow;

    public int setArrowToInput;
    public int RNGArrowChoice;
    private int PlayerInput;
    private bool isReverse;


    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = null;
        DeployArrow();
        CheckInRangeArrow(Enemy.GetComponent<EnemyScript>().inRange);
    }

    void DeployArrow()
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

                this.GetComponent<SpriteRenderer>().color = yellow;
                break;

            case 3:
                // Reverse + Moving, not sure if will work 2 colors

                isReverse = true;
                this.GetComponent<SpriteRenderer>().color = red + yellow;
                break;
        }

    }


    public void GetPlayerInput(int input)
    {
        PlayerInput = input;
    }

    private void LateUpdate()
    {
        CheckInRangeArrow(Enemy.GetComponent<EnemyScript>().inRange);

        if (PlayerInput == setArrowToInput)
        {
            Destroy(Enemy);
        }
    }


    void CheckInRangeArrow(bool inRange)
    {
        if (inRange)
        {
            this.GetComponent<SpriteRenderer>().sprite = ArrowSprites[setArrowToInput];
        }
        else
        {
            this.StartCoroutine(SpinArrow(inRange));
        }
    }

    // They spin all arrows and not stop

    IEnumerator SpinArrow(bool inRange)
    {
        if (!inRange)
        {
            int randomArrow = Random.Range(1, 4);
            this.GetComponent<SpriteRenderer>().sprite = ArrowSprites[randomArrow];

            yield return new WaitForSeconds(1);
        }
    }
}
