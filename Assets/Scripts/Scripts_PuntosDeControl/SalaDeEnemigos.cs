using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

public class SalaDeEnemigos : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;
    [SerializeField] private int maxEnemigosTotal = 10; // Total de enemigos que aparecen en la sala
    [SerializeField] private int maxEnemigosSimultaneos = 3; // Límite en pantalla
    [SerializeField] private GameObject[] muros; // Arrastrar los muros aquí
    [SerializeField] private CinemachineVirtualCamera camaraSala;
    [Header("Puertas")]
    [Header("Cinemachine")]
    private int enemigosInvocados = 0;
    private float tiempoSiguienteEnemigo;
    private bool jugadorEnRango = false; // Controla si el spawn está activo
    private bool salaCompletada = false;
    private void Start()
    {
        // Calculamos los límites (tu código de LINQ)
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);

        // APAGAR LOS MUROS AL EMPEZAR
        // Si arrastraste el objeto "Padre", esto apagará a sus hijos también.
        foreach (GameObject muro in muros)
        {
            muro.SetActive(false);
        }
    }

    private void Update()
    {
        // 1. Si el jugador está en rango y la sala NO se ha completado...
        if (jugadorEnRango && !salaCompletada)
        {
            // 2. Si todavía quedan enemigos por invocar
            if (enemigosInvocados < maxEnemigosTotal)
            {
                int enemigosVivos = GameObject.FindGameObjectsWithTag("Enemigo").Length;

                if (enemigosVivos < maxEnemigosSimultaneos)
                {
                    tiempoSiguienteEnemigo += Time.deltaTime;
                    if (tiempoSiguienteEnemigo >= tiempoEnemigos)
                    {
                        tiempoSiguienteEnemigo = 0;
                        CrearEnemigo();
                        enemigosInvocados++;
                    }
                }
            }
            // 3. SI YA SE INVOCARON LOS 10 Y NO QUEDA NINGUNO VIVO
            else if (GameObject.FindGameObjectsWithTag("Enemigo").Length == 0)
            {
                TerminarSala(); // <--- Aquí es donde ocurre la magia
            }
        }
    }

    // Se activa cuando algo entra en el Collider

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !salaCompletada)
        {
            jugadorEnRango = true;

            // Subimos la prioridad para que Cinemachine haga la transición suave
            camaraSala.Priority = 20;

            foreach (GameObject muro in muros) muro.SetActive(true);
        }
    }

    private void TerminarSala()
    {
        salaCompletada = true;
        camaraSala.Priority = 5;

        // El error CS0103 suele pasar porque falta la línea del 'foreach' 
        // o está mal escrita la variable dentro del paréntesis.
        foreach (GameObject muro in muros)
        {
            muro.SetActive(false); // Aquí 'muro' (en singular) ya existe
        }

        Debug.Log("¡Sala despejada!");
    }

    private void CrearEnemigo()
    {
    int numeroEnemigo = Random.Range(0, enemigos.Length);
    Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
}
