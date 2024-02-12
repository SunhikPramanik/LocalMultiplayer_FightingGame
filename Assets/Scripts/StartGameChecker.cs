using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGameChecker : MonoBehaviour
{
    public string levelToLoad;

    private int playersInZone;

    public TMP_Text startcountText;

    public float timeToStart = 3f;
    private float startCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playersInZone > 1 && playersInZone == GameManager.instance.activePlayers.Count)
        {
            if(!startcountText.gameObject.activeInHierarchy)
            {
                AudioManager.instance.PlaySFX(3);
            }

            startcountText.gameObject.SetActive(true);

            startCounter -= Time.deltaTime;

            startcountText.text = Mathf.CeilToInt(startCounter).ToString();

            if(startCounter <= 0)
            {
                //SceneManager.LoadScene(levelToLoad);
                //GameManager.instance.GoToNextArena();
                GameManager.instance.StartFirstRound();
            }
        } else
        {
            startcountText.gameObject.SetActive(false);
            startCounter = timeToStart;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playersInZone++;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playersInZone--;

        }
    }
}
