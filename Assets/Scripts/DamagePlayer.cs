using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageToDeal = 1;

    

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
        if (other.tag == "Player" && GameManager.instance.canFight)
        {
            other.GetComponent<PlayerHealthController>().DamagePlayer(damageToDeal);
        }
    }
}
