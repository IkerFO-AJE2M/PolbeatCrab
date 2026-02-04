using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaSuperposicion : MonoBehaviour
{
    public GameObject canvasParaMostrar; // Arrastra aquí tu Canvas desde el Inspector

    // Este método lo llamaremos desde el botón
    public void ActivarCanvas()
    {
        canvasParaMostrar.SetActive(true); // Activa el Canvas
    }

    public void DesactivarCanvas()
    {
        canvasParaMostrar.SetActive(false); // Para ocultarlo si quieres
    }
}
