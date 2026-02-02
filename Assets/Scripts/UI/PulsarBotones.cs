using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsarBotones : MonoBehaviour
{
    public GameObject mainMonitor; // Monitor que cambia de textura

    public Material[] mats; // Materiales que son fuente de la pantalla principal

    public int n; // Numero del material que va a ser nuestra fuente

    public GameObject[] botonesCanal; // Lista de botones canal

    private Color colorDefecto = Color.white; // Color blanco por defecto

    public Color colorCambio; // Asignar el color al que queremos cambiar desde el inspector

    MeshRenderer meshRenderer; // Almacena el material del boton 

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>(); // Obtener el MeshRenderer del objeto
    }

    private void OnMouseDown()
    {
        DesactivarColor(); // Ejecuta la función desactiva color en todos los botones 

        if(meshRenderer !=null && meshRenderer.material != null)
        {
            meshRenderer.material.color = colorCambio;// Cambiamos el color del material
        }

        mainMonitor.GetComponent<MeshRenderer>().sharedMaterial = mats [n]; // Carga el material de la pantalla y le asigna el material con numero n
    }

    private void DesactivarColor()
    {
        // Todos los botones del array se pongan del color por defecto
        foreach (GameObject obj in botonesCanal)
        {
            // obtiene el componente Renderer de cada objeto
            Renderer renderer = obj.GetComponent<Renderer>();

            if (renderer != null)
            {
                // Accede al material de Renderer y cambia su color al defecto
                renderer.material.color = colorDefecto;
            }
              
        }
    }
}
