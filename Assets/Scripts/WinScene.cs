using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScene : MonoBehaviour
{
    public Canvas gameCanvas;
    public Canvas winCanvas;

    public Camera mainCamera;
    public Camera winCamera;
    public Camera loseCamera;

    public GameObject madBouncer;

    public void ActivateWinCanvas()
    {
        mainCamera.gameObject.SetActive(false);

        winCamera.gameObject.SetActive(true);

        madBouncer.SetActive(false);
    }

    public void ActivateLoseCanvas()
    {
        mainCamera.gameObject.SetActive(false);

        loseCamera.gameObject.SetActive(true);
        madBouncer.SetActive(true);
    }
}
