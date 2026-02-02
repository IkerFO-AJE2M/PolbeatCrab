using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Carga librerias gestión de escenas

public class CambioEscenAnimatica : MonoBehaviour
{
    public float delay = 10f;
    public string nombreEscena;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("IniciarCarga", 30f); // Ejecuta la función IniciarCarga pasados 10 segundos
    }


    public void IniciarCarga()
    {
        SceneManager.LoadScene(nombreEscena); //Carga una escena
    }
}
