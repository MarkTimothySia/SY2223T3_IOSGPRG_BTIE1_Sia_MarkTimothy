using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] float movementSpeed = 1.0f;
    // maybe arrow here?

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy Enemy
        Destroy(this.gameObject);
    }
}
