using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject menuPausa; // Arrastra tu panel de pausa aquí desde el Inspector
    private bool juegoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f; // El tiempo vuelve a transcurrir normalmente
        juegoPausado = false;
    }

    void Pause()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f; // El tiempo se detiene por completo
        juegoPausado = true;
    }
}
