using UnityEngine;

public class CamaraIndependiente2D : MonoBehaviour
{
    [Header("Configuración del Objetivo")]
    [Tooltip("El transform del personaje a seguir")]
    public Transform objetivo;

    [Header("Teclas a Detectar")]
    [Tooltip("Teclas que indican movimiento a la derecha")]
    public KeyCode[] teclasDerechaDerecha = { KeyCode.D, KeyCode.RightArrow };
    [Tooltip("Teclas que indican movimiento a la izquierda")]
    public KeyCode[] teclasIzquierda = { KeyCode.A, KeyCode.LeftArrow };

    [Header("Configuración de Desplazamiento")]
    [Tooltip("Desplazamiento base de la cámara")]
    public Vector3 desplazamiento = new Vector3(0f, 1f, -10f);

    [Header("Suavizado")]
    [Tooltip("Velocidad de suavizado del movimiento")]
    [Range(0f, 1f)]
    public float velocidadSuavizado = 0.15f;

    [Header("Anticipación de Mirada")]
    [Tooltip("Distancia de anticipación horizontal")]
    public float distanciaAnticipacion = 3f;
    [Tooltip("Velocidad de la anticipación")]
    [Range(0f, 1f)]
    public float velocidadAnticipacion = 0.1f;

    [Header("Límites (Opcional)")]
    public bool usarLimites = false;
    public float minX, maxX;
    public float minY, maxY;

    private float direccionActual = 1f; // Última dirección conocida
    private float anticipacionActual = 0f;

    private void LateUpdate()
    {
        if (objetivo == null) return;

        // Detectar si se está presionando alguna tecla de dirección
        bool presionandoDerecha = false;
        bool presionandoIzquierda = false;

        foreach (KeyCode tecla in teclasDerechaDerecha)
        {
            if (Input.GetKey(tecla))
            {
                presionandoDerecha = true;
                break;
            }
        }

        foreach (KeyCode tecla in teclasIzquierda)
        {
            if (Input.GetKey(tecla))
            {
                presionandoIzquierda = true;
                break;
            }
        }

        // Actualizar dirección solo si se presiona una tecla
        if (presionandoDerecha && !presionandoIzquierda)
        {
            direccionActual = 1f; // Derecha
        }
        else if (presionandoIzquierda && !presionandoDerecha)
        {
            direccionActual = -1f; // Izquierda
        }
        // Si no se presiona nada o ambas, mantener la última dirección

        // Suavizar la anticipación hacia la dirección actual
        float anticipacionObjetivo = direccionActual * distanciaAnticipacion;
        anticipacionActual = Mathf.Lerp(anticipacionActual, anticipacionObjetivo, velocidadAnticipacion);

        // Calcular posición deseada
        Vector3 offsetAnticipacion = new Vector3(anticipacionActual, 0f, 0f);
        Vector3 posicionDeseada = objetivo.position + desplazamiento + offsetAnticipacion;

        // Suavizar el movimiento
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidadSuavizado);

        // Aplicar límites si están activados
        if (usarLimites)
        {
            posicionSuavizada.x = Mathf.Clamp(posicionSuavizada.x, minX, maxX);
            posicionSuavizada.y = Mathf.Clamp(posicionSuavizada.y, minY, maxY);
        }

        // Mantener la Z
        posicionSuavizada.z = desplazamiento.z;

        transform.position = posicionSuavizada;
    }

    /// <summary>
    /// Cambia el objetivo que la cámara debe seguir
    /// </summary>
    /// <param name="nuevoObjetivo">Transform del nuevo objetivo a seguir</param>
    public void CambiarObjetivo(Transform nuevoObjetivo)
    {
        if (nuevoObjetivo != null)
        {
            objetivo = nuevoObjetivo;
            Debug.Log($"Cámara cambió su objetivo a: {nuevoObjetivo.name}");
        }
        else
        {
            Debug.LogWarning("Se intentó cambiar a un objetivo nulo");
        }
    }
}