using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{

    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript enemyScript = collision.GetComponent<EnemyScript>();

        if (enemyScript != null)
        {
            player.GetComponent<PlayerScript>().AddEnemyToList(collision.gameObject);
        }
    }
}
