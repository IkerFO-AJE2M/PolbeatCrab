using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Carga libreria gestion de escenas

public class ChangeScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //Comprueba si pulsamos la tecla Esc
        {
            End(); //ejecutando la funcion End
        }
    }
    public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //Carga una escena
    }

    public void End()
    {
        Debug.Log("Se termino");
        Application.Quit(); //Sale del programa
    }
}
