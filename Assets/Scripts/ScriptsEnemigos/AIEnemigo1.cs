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
    public int enemyHealth;
    public int damageTaken = 3;


    //var. Animations
    private bool walking;
    private bool idle;
    public PlayerControllerCarril playerController;

    [SerializeField] Transform jugador;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    public EnemigoAvanzado cucaracho;
    public bool mirandoDerecha = false;
    public Animator animator;
    public GameObject HitboxEnemy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        player = GameObject.FindGameObjectWithTag("Player");

        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        if (player != null)
        {
            jugador = player.transform;
        }
        StartCoroutine(Dead());

       /* 
        if (enemyHealth <= 0)
        {
            cucaracho.enabled = false;
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Dead"))
            {
                Destroy(this.gameObject);
            }
            else
            {
                animator.SetTrigger("Dead");
            }
        }
       */
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

            if (attackDelay <= attackTimer && playerController.healthCrab > 0)
            {
                animator.SetTrigger("Attack");
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

    IEnumerator Dead()
    {
        if (enemyHealth <= 0)
        {
            animator.SetTrigger("Dead");

            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Dead"))
            {
                Destroy(this.gameObject);
            }
            
        }
        yield return null;
    }

    public void ReciveDamage()
    {
        enemyHealth -= damageTaken;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HitboxPlayer"))
        {
            ReciveDamage();
        }
    }
}