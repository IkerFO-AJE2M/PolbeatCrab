using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Sprite sonido;
    public Sprite noSonido;
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
        CambiarHandle();

    }

    void CambiarHandle()
    {
        if (sliderValue == 0)
        {
            handle.sprite = noSonido;
        }
        else
        {
            handle.sprite = sonido;
        }
    }
}
