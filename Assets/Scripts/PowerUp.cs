using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool isHealth, isInvincible, isSpeed, isGravity;

    public float powerupLength, powerUpAmount;

    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (isHealth)
            {
                other.GetComponent<PlayerHealthController>().FillHealth();

                AudioManager.instance.PlaySFX(8);
            }

            if(isInvincible)
            {
                other.GetComponent<PlayerHealthController>().MakeInvincible(powerupLength);

                AudioManager.instance.PlaySFX(9);
            }

            if(isSpeed)
            {
                PlayerController thePlayer = other.GetComponent<PlayerController>();
                thePlayer.moveSpeed = powerUpAmount;
                thePlayer.powerUpCounter = powerupLength;

                AudioManager.instance.PlaySFX(10);
            }

            if(isGravity)
            {
                PlayerController thePlayer = other.GetComponent<PlayerController>();
                thePlayer.powerUpCounter = powerupLength;
                thePlayer.theRB.gravityScale = powerUpAmount;

                AudioManager.instance.PlaySFX(11);
            }

            Instantiate(pickupEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
