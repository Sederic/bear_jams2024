using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    
    string sceneToLoadName;
    GameManager gameManager;


    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene(2);
    }
    public void StartGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void NavigateToScene()
    {
        SceneManager.LoadScene(sceneToLoadName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
