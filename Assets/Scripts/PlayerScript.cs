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
    Collider2D EnemyTracker;
    protected bool isInvinsible = false;
    protected bool isAlive = true;
    Rigidbody2D playerRigidbody;
    TextMeshProUGUI hpText;

    // public GameObject[] Enemies;
    private List<GameObject> enemies;
    private int totalEnemies;

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
            currentHp--;
            hpText.text = currentHp.ToString();
        }
        else if (currentHp <= 0 && !isInvinsible)
        {
            currentHp = 0;

            // just loads self scene
            SceneManager.LoadScene(0);

        }

    }

    // Can call anytime, sadly cannot use since I can't kill enemies
    public void OnInvincibilityMode()
    {
        StartCoroutine(C_EnableInvincibility());
    }

    IEnumerator C_EnableInvincibility()
    {
        UnityEngine.Debug.Log("Player Invincible");
        isInvinsible = true;

        yield return new WaitForSeconds(5);


        UnityEngine.Debug.Log("Player not Invincible");
        isInvinsible = false;
    }

    /* public void Attack(SwipeDirection swipeDirection)
    {
        // check the swipe direction for the first enemy in enemy list
        if (enemies[0].swipeDirection == swipeDirection)
        {
            // kill enemy
        }
    }*/
}
