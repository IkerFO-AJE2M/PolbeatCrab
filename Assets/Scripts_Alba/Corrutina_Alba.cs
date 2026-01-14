using System.Collections;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public float tiempoAntesDeMover = 2f;  // segundos antes de moverse
    public float velocidad = 2f;           // velocidad del enemigo
    public Vector2 objetivo = new Vector2(5f, 0f); // posición a donde se mueve

    void Start()
    {
        // Inicia la corrutina al crear el enemigo
        StartCoroutine(VidaDelEnemigo());
    }

    IEnumerator VidaDelEnemigo()
    {
        Debug.Log("Enemigo aparece!");

        // Espera antes de moverse
        yield return new WaitForSeconds(tiempoAntesDeMover);

        // Moverse hacia la posición objetivo
        while ((Vector2)transform.position != objetivo)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);
            yield return null; // espera hasta el siguiente frame
        }

        Debug.Log("Enemigo llegó a su destino. Desapareciendo...");

        // Espera un segundo antes de desaparecer
        yield return new WaitForSeconds(1f);

        // Destruye el objeto
        Destroy(gameObject);
    }
}

