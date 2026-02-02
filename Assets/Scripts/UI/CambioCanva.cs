using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCanva : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasJuego;

    public void IrAJuego()
    {
        canvasMenu.SetActive(false);
        canvasJuego.SetActive(true);
    }

    public void IrAMenu()
    {
        canvasJuego.SetActive(false);
        canvasMenu.SetActive(true);
    }
}
