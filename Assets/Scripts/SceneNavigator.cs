using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    [SerializeField]
    string sceneToLoadName;

    public void StartGameScene()
    {
        SceneManager.LoadScene(2);
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
