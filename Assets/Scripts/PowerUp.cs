using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    Color green = Color.green;
    Color blue = Color.blue;

    int PowerUpNumber;

    private void Start()
    {
        PowerUpNumber = Random.Range(0, 1);

        if (PowerUpNumber == 0)
        {
            this.GetComponent<SpriteRenderer>().color = blue;
        }
        else if (PowerUpNumber == 1)
        {
            this.GetComponent<SpriteRenderer>().color = green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();

        if (playerScript != null)
        {
            OnPowerUp(playerScript);
        }
    }

    // I never tried but does this work? for OOP?
    protected virtual void OnPowerUp(PlayerScript playerScript)
    {

        // 0 = StarMode, 1 = Healing

        if (PowerUpNumber == 0)
        {
            playerScript.OnInvincibilityMode();
        }
        else if (PowerUpNumber == 1)
        {
            playerScript.PlayerHealing();
        }
    }

}
