using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectButton : MonoBehaviour
{
    public SpriteRenderer theSR;

    public Sprite buttonUp, buttonDown;

    public bool isPressed;

    public float waitToPopUp;
    private float popCounter;

    public AnimatorOverrideController theController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            popCounter -= Time.deltaTime;

            if(popCounter <= 0)
            {
                isPressed = false;

                theSR.sprite = buttonUp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isPressed)
        {
            PlayerController thePlayer = other.GetComponent<PlayerController>();

            if (thePlayer.theRB.velocity.y < -.1f)
            {
                thePlayer.anim.runtimeAnimatorController = theController;

                isPressed = true;

                theSR.sprite = buttonDown;

                popCounter = waitToPopUp;
            }

            AudioManager.instance.PlaySFX(2);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && isPressed)
        {
            isPressed = false;

            theSR.sprite = buttonUp;
        }
    }
}
