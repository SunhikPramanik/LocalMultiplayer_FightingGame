using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exitPoint;

    public GameObject warpEffect;

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
            other.transform.position = exitPoint.position;

            Instantiate(warpEffect, transform.position, transform.rotation);
            Instantiate(warpEffect, exitPoint.position, exitPoint.rotation);

            AudioManager.instance.PlaySFX(7);
        }
    }
}
