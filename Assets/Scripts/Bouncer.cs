using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public SpriteRenderer theSR;

    public Sprite downSprite, upSprite;

    public float stayUpTime, bouncePower;
    private float upCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(upCounter > 0)
        {
            upCounter -= Time.deltaTime;

            if(upCounter <= 0)
            {
                theSR.sprite = downSprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            upCounter = stayUpTime;
            theSR.sprite = upSprite;

            Rigidbody2D theRB = other.GetComponent<Rigidbody2D>();

            theRB.velocity = new Vector2(theRB.velocity.x, bouncePower);

            AudioManager.instance.PlaySFX(6);
        }
    }
}
