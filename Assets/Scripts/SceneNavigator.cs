using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    
    string sceneToLoadName;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene(5);
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
