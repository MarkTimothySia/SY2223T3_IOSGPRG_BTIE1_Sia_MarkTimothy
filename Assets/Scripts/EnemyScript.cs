using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] float movementSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedMultiplier;

    SetArrow Script;
    
    public bool inRange = false;

    private void LateUpdate()
    {
        rb.AddForce(- transform.up * ( movementSpeed * speedMultiplier ) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy Enemy
        Destroy(this.gameObject);
    }

}
