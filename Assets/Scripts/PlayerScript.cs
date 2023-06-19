using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int currentHp;
    [SerializeField] EnemySpawner spawner;
    [SerializeField] TextMeshProUGUI hpText;

    Collider2D EnemyTracker;
    protected bool isInvinsible = false;
    protected bool isAlive = true;
    Rigidbody2D playerRigidbody;

    private List<GameObject> enemies;
    private int currentEnemy = 0;

    private void Start()
    {
        StartCoroutine(C_AddSpeed());
    }

    private void Update()
    {
        hpText.text = "HP: " + currentHp.ToString();
    }


    // Add abilities here
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When player gets hit, HP - 1
        EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();

        if (enemyScript != null)
        {
            TakeDamage();
            enemyScript.KillEnemy();
            enemies.Remove(enemyScript.gameObject);
        }
    }

    public void AddEnemyToList(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void TakeDamage()
    {

        if (currentHp > 0 && !isInvinsible)
        {
            currentHp = currentHp - 1;
            hpText.text = currentHp.ToString();
        }
        else if (currentHp <= 0 && !isInvinsible)
        {
            currentHp = 0;

            // just loads self scene
            SceneManager.LoadScene(0);

        }
    }

    IEnumerator C_AddSpeed()
    {
        yield return new WaitForSeconds(2);

        spawner.AddSpeed();

        StartCoroutine(C_AddSpeed());
    }

    public void Attack(SwipeDirection swipeDirection)
    {
        //// check the swipe direction for the first enemy in enemy list
        //if (enemies[0].swipeDirection == swipeDirection)
        //{
        //    // kill enemy
        //}

        // Hopefully would kill each time


        if (enemies[currentEnemy].GetComponent<SetArrow>().GetArrowToBeInput() == swipeDirection)
        {
            enemies[currentEnemy].GetComponent<EnemyScript>().KillEnemy();
            currentEnemy += 1;
        }

    }

    // Can call anytime, sadly cannot use since I can't kill enemies
    public void OnInvincibilityMode()
    {
        StartCoroutine(C_EnableInvincibility());
    }

    public void PlayerHealing()
    {
        currentHp += 1;
    }

    IEnumerator C_EnableInvincibility()
    {
        UnityEngine.Debug.Log("Player Invincible");
        isInvinsible = true;

        yield return new WaitForSeconds(5);


        UnityEngine.Debug.Log("Player not Invincible");
        isInvinsible = false;
    }
}
