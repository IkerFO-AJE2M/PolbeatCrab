using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Carga libreria gestion de escenas

public class ChangeScene : MonoBehaviour
{
   
    public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //Carga una escena
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");


    }
}
