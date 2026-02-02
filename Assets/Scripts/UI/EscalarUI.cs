using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalarUI : MonoBehaviour
{
    public RectTransform panel;
    public float escalaGrande = 2f;
    public float duracion = 0.1f;

    bool agrandado = false;
    Coroutine anim;

    public void ToggleEscala()
    {
        if (anim != null)
            StopCoroutine(anim);

        agrandado = !agrandado;
        anim = StartCoroutine(AnimarEscala(agrandado ? Vector3.one * escalaGrande : Vector3.one));
        
        Debug.Log("CLICK");
    }

    IEnumerator AnimarEscala(Vector3 objetivo)
    {
        Vector3 inicio = panel.localScale;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duracion;
            panel.localScale = Vector3.Lerp(inicio, objetivo, t);
            yield return null;
        }

        panel.localScale = objetivo;
    }
}
