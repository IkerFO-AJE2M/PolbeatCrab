using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    public Color nuevoColor; // Asignar un color desde el inspector

    // Start is called before the first frame update
    void Start()
    {
        // Obtener el componente MeshRender  
        MeshRenderer meshRender = GetComponent<MeshRenderer>();

        // Verificamos si el objeto tiene un MeshRender y un material

        if (meshRender != null && meshRender.material != null)
        {
            // Cambiamos de color 
            meshRender.material.color = nuevoColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
