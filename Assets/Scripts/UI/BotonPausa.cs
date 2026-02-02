using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPausa : MonoBehaviour
{
    public GameObject pauseCanvas;

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
