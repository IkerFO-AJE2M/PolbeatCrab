using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen1 : MonoBehaviour
{
    public Sprite musica;
    public Sprite noMusica;
    public Image handle;
    public Slider mySlider; // Arrastra tu Slider desde el Inspector
    private float sliderValue; // Aquí guardaremos el valor

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = mySlider.value;
        Debug.Log(sliderValue); // Opcional: ver el valor en consola
        CambiarHandle2();

    }

    void CambiarHandle2()
    {
        if (sliderValue == 0)
        {
            handle.sprite = noMusica;
        }
        else
        {
            handle.sprite = musica;
        }
    }
}
