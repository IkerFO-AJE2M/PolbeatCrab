using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPausa : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject hudCanvas;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);
        hudCanvas.SetActive(!pauseCanvas.activeSelf);
    }

    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
    }

    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
    }
}
