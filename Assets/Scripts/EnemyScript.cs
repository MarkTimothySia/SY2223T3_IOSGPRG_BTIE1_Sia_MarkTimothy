using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;
using Unity.VisualScripting;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] float movementSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedMultiplier;
    [SerializeField] SetArrow Script;
    [SerializeField] Collider2D TriggerRangeCircle;
    [SerializeField] int enemyTimer = 10;


    private Swipe SwipeManager = null;
    private GameObject player;
    private int playerInput;
    
    public bool inRange = false;

    private void Start()
    {
        SetSwipeManager(SwipeManager);
        // StartCoroutine(C_AutoDestroy());
    }

    private void Update()
    {
        Script.GetPlayerInput(playerInput);
    }

    private void LateUpdate()
    {
        rb.AddForce(- transform.up * ( movementSpeed * speedMultiplier ) * Time.deltaTime);
    }


    // Not sure why does not trigger this collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("Enemy touching?");
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage();
            KillEnemy();
        }
    }


    // Not sure why does not work, to turn off in SetArrow

    private void OnTriggerStay2D(Collider2D RangeCircle)
    {
        RangeCircle = TriggerRangeCircle;

        if (RangeCircle.gameObject.tag == "Player")
        {
            inRange = true;


            UnityEngine.Debug.Log("In Range");
        }

    }
    public void SetSpeedMultiplier(float SpeedMulti)
    {
        speedMultiplier = SpeedMulti;
    }
    public void KillEnemy()
    {
        Destroy(this.gameObject);
    }

    public void SetSwipeManager(Swipe Swipe)
    {
        SwipeManager = Swipe;
    }
    public void SetPlayer(GameObject Player)
    {
        player = Player;
        // Not sure, but we need a reference here
    }

    //IEnumerator C_AutoDestroy()
    //{
    //    yield return new WaitForSeconds(enemyTimer);
    //    Destroy(this.gameObject);
    //}


}
