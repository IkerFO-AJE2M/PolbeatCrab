using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Cargar Libreria

public class PulsarObjeto : MonoBehaviour
{
    public Canvas canvasSuperposicion; //Variable donde alojamosel canvas que queremos superponer

    private void OnMouseOver()
    {
        ActivarSuperposicion();// LLama a ala funcion con ese nombre
    }
    private void OnMouseExit()
    {
        DesactivarSuperposicion();// LLama a ala funcion con ese nombre
    }

    public void ActivarSuperposicion()
    {
        canvasSuperposicion.gameObject.SetActive(true); //Activa el canvas
    }
    public void DesactivarSuperposicion()
    {
        canvasSuperposicion.gameObject.SetActive(false); //Activa el canvas
    }
}
