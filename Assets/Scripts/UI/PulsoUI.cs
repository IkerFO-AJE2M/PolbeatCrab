using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsoUI : MonoBehaviour
{
    public RectTransform panel;   // PanelEscala
    public float escalaMin = 1f;
    public float escalaMax = 1.3f;
    public float duracion = 1f;   // tiempo de un ciclo completo

    private bool animando = true;

    void Start()
    {
        StartCoroutine(Pulso());
    }

    IEnumerator Pulso()
    {
        while (animando)
        {
            // De min a max
            yield return Escalar(panel, escalaMin, escalaMax);
            // De max a min
            yield return Escalar(panel, escalaMax, escalaMin);
        }
    }

    IEnumerator Escalar(RectTransform target, float desde, float hasta)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / (duracion / 2f);
            float escala = Mathf.Lerp(desde, hasta, t);
            target.localScale = Vector3.one * escala;
            yield return null;
        }
    }

    // Llamar desde el botón
    public void Detener()
    {
        animando = false;
    }
}
