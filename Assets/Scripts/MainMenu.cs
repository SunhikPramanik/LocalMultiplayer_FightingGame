using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameStartScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

#endif
    }
}
