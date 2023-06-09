using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int currentHp;

    protected bool isInvinsible = false;
    protected bool isAlive = true;
    Rigidbody2D playerRigidbody;
    TextMeshProUGUI hpText;


    // Add abilities here
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When player gets hit, HP - 1

        if (collision.gameObject.tag == "Enemy") 
        {

            UnityEngine.Debug.Log("Enemy touched");
            TakeDamage();

            collision.gameObject.GetComponent<EnemyScript>().KillEnemy();
        }
    }


    public void TakeDamage()
    {

        if (currentHp > 0 && !isInvinsible) 
        {
            currentHp--;
            hpText.text = currentHp.ToString();
        }
        else if(currentHp <= 0 && !isInvinsible)
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

}
