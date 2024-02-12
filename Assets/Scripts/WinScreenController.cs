using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{
    public TMP_Text winText;
    public Image playerImage;

    public string mainMenuScene, charSelectScene;

    // Start is called before the first frame update
    void Start()
    {
        winText.text = "Player " + (GameManager.instance.lastPlayerNumber + 1) + " Wins The Game!";
        playerImage.sprite = GameManager.instance.activePlayers[GameManager.instance.lastPlayerNumber].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        GameManager.instance.StartFirstRound();
    }

    public void SelectCharacters()
    {
        ClearGame();

        SceneManager.LoadScene(charSelectScene);
    }

    public void MainMenu()
    {
        ClearGame();

        SceneManager.LoadScene(mainMenuScene);
    }

    public void ClearGame()
    {
        foreach (PlayerController player in GameManager.instance.activePlayers)
        {
            Destroy(player.gameObject);
        }

        Destroy(GameManager.instance.gameObject);
        GameManager.instance = null;
    }
}
