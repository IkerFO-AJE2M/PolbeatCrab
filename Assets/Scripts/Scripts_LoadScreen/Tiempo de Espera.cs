using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Carga libreria gestion de escenas

public class TiempodeEspera : MonoBehaviour
{
    public float delay = 10f; //Tiempo de espera
    public string nombreEscena; //Nombre de la escena a cargar

    // Start is called before the first frame update
    void Start()
    {
        Invoke("IniciarCarga", delay); //Ejecuta la funcion IniciarCarga pasados 10 segundos
    }

    // Update is called once per frame

    public void IniciarCarga()
    {
        SceneManager.LoadScene(nombreEscena); //Carga la escena inicio
    }
}
