using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemigoAvanzado : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 3.5f;
    public float distanciaSeguimiento = 12f;
    public float distanciaParada = 1.2f;
    public float attackDelay = 1f;
    private float attackTimer;

    //var. Animations
    private bool walking;
    private bool idle;


    [Header("Animaciones")]
    [SerializeField] Transform jugador;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject player;
    public bool mirandoDerecha = false;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        // Bloquear Y y rotación
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        if (player != null)
        {
            jugador = player.transform;
        }
    }

    void FixedUpdate()
    {

        if (jugador == null) return;

        float distanciaHorizontal = Mathf.Abs(jugador.position.x - transform.position.x);

        if (rb.velocity != new Vector2(0f, 0f))
        {
            walking = true;
            idle = false;
        }
        else
        {
            walking = false;
            idle = true;
        }

        // Solo avanza si está lo suficientemente lejos
        if (distanciaHorizontal < distanciaSeguimiento && distanciaHorizontal > distanciaParada)
        {
            MoverHaciaJugador();
        }
        else
        {
            rb.velocity = Vector2.zero;
            attackTimer += Time.deltaTime;

            if (attackDelay <= attackTimer)
            {
                animator.SetTrigger("Attack");
                Debug.Log("Ataca?");
                attackTimer = 0f;
            }
        }

        animator.SetBool("Walking", walking);
        animator.SetBool("Idle", idle);
    }

    void MoverHaciaJugador()
    { 
        float direccionX = Mathf.Sign(jugador.position.x - transform.position.x);

        rb.velocity = new Vector2(direccionX * velocidad, 0f);

        // Girar sprite
        if (direccionX > 0 && !mirandoDerecha)
            Flip();
        else if (direccionX < 0 && mirandoDerecha)
            Flip();
    }

    void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.Rotate(0f, 180f, 0f);
    }


    /*
    [Header("Configuración de Movimiento")]
    public float velocidad = 3.5f;
    public float distanciaSeguimiento = 12f;
    public float distanciaAtaque = 0.5f;

    [Header("IA de Profundidad (Eje Y)")]
    public float variacionY = 0.5f; // Cuánto se desvía del jugador arriba/abajo
    public float tiempoCambioDesvio = 1f; // Cada cuánto tiempo cambia su objetivo vertical

    private Transform jugador;
    private Rigidbody2D rb;
    private float desvioActualY;
    private float cronometroDesvio;
    private bool mirandoDerecha = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Importante: El jugador DEBE tener el Tag "Player" en el Inspector
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) jugador = playerObj.transform;

        // Iniciar con un desvío aleatorio
        ActualizarDesvio();
    }

    void Update()
    {
        if (jugador == null) return;

        // Actualizar el desvío aleatorio periódicamente para que el movimiento sea fluido
        cronometroDesvio += Time.deltaTime;
        if (cronometroDesvio >= tiempoCambioDesvio)
        {
            ActualizarDesvio();
        }
    }

    void FixedUpdate()
    {
        if (jugador == null) return;

        float distanciaHorizontal = Mathf.Abs(jugador.position.x - transform.position.x);
        float distanciaVertical = Mathf.Abs(jugador.position.y - transform.position.y);

        // Si está en rango de seguimiento pero no lo suficientemente cerca para atacar
        if (distanciaHorizontal < distanciaSeguimiento && distanciaHorizontal > distanciaAtaque)
        {
            MoverHaciaJugador();
        }
        else
        {
            rb.velocity = Vector2.zero; // Se detiene si está muy lejos o en rango de ataque
        }
    }

    void MoverHaciaJugador()
    {
        // El objetivo real es el jugador + un pequeño desvío aleatorio en Y
        Vector2 objetivo = new Vector2(jugador.position.x, jugador.position.y + desvioActualY);
        Vector2 direccion = (objetivo - (Vector2)transform.position).normalized;

        rb.velocity = direccion * velocidad;

        // Volteo de Sprite
        if (direccion.x > 0 && !mirandoDerecha) Flip();
        else if (direccion.x < 0 && mirandoDerecha) Flip();
    }

    void ActualizarDesvio()
    {
        desvioActualY = Random.Range(-variacionY, variacionY);
        cronometroDesvio = 0;
    }

    void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.Rotate(0f, 180f, 0f);
    }
    */
}