using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayerKeyboard2 : MonoBehaviour
{
    public GameObject playerToLoad;

    private bool hasLoadedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null)
        {
            if (!hasLoadedPlayer && GameManager.instance.activePlayers.Count < GameManager.instance.maxPlayers)
            {
                if (Keyboard.current.jKey.wasPressedThisFrame || Keyboard.current.lKey.wasPressedThisFrame || Keyboard.current.rightShiftKey.wasPressedThisFrame || Keyboard.current.iKey.wasPressedThisFrame || Keyboard.current.kKey.wasPressedThisFrame)
                {
                    Instantiate(playerToLoad, transform.position, transform.rotation);

                    hasLoadedPlayer = true;
                }
            }
        }
    }
}
