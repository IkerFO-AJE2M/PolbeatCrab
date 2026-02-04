using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerCarril : MonoBehaviour
{
    // Variables Float
    public float horizontalInput;
    public float baseSpeedX;
    public float xSpeed;
    public float ySpeed;
    public float speedMultiplierX;
    public float umbralTiempo;
    private float TiempoCargado;
    public float jumpForce = 1000;
    public float _rbSpeed;
    public float posibleJumps;
    public float currentJumps;
    public float healthCrab;
    public float maxHealthCrab;
    public float damageCrab;
    public int damageToTake = 1;

    // Varialbes Bool
    private bool jPress;
    private bool jAirPress;
    private bool kPress;
    private bool isAttacking;
    private bool isJumping;
    private bool isGrounded;
    private bool kAirPress;
    private bool isDefending;
    private bool _facingRight;

    //Variables de Componente
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D _rbPlayer;
    [SerializeField] LayerMask Ground;
  //  public GameObject hitbox;
    public Slider healthBar;
    public PlayerControllerCarril playerController;

    //Variables Compuestas
    private Vector2 movement;


    void Start()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
        healthCrab = maxHealthCrab;

       healthBar.value = healthCrab;
       healthBar.maxValue = maxHealthCrab;

        playerController = GetComponent<PlayerControllerCarril>();
    }
    void Update()
    {
        healthBar.value = healthCrab;

        //Actualizamos la velocidad del Rigidbody cada frame
        _rbSpeed = _rbPlayer.velocity.magnitude;

        //Cambiamos elvalor del Movement
        movement = new Vector2(horizontalInput, 0f);

        //Corregimos la orientación del sprite

        //Miramos si está atacando
        AnimationTagCheck();

        #region MOVEMENT.MODIFIERS
        //Nos aseguramos de que este pulsando o no el botón de correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            xSpeed = baseSpeedX * speedMultiplierX;
        }
        else
        {
            xSpeed = baseSpeedX;
        }

        //JAttack();
        Pinch();
        Jump();
        Contusion();
        Twirl();
        Drill();
        Defend();

        #endregion


        //Aplicamos el movimiento
        #region MOVEMENT
        if (isAttacking == false && isDefending == false)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal"); //Detecta cuando pulsas las flechas Izquierda / Derecha

            transform.Translate(Vector2.right * Time.deltaTime * xSpeed * horizontalInput);

            if (horizontalInput < 0f && _facingRight == true)
            {
                SpriteFlip();
            }
            else if (horizontalInput > 0f && _facingRight == false)
            {
                SpriteFlip();
            }
            /* verticalInput = Input.GetAxisRaw("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

             transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);
            */
        }

        #endregion

        //Relacionamos variables con el Animator
        #region AnimatorBools
        animator.SetBool("KAirPress", kAirPress);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("Jump", isJumping);
        animator.SetBool("Attack", isAttacking);
        animator.SetBool("JPress", jPress);
        animator.SetBool("JAirPress", jAirPress);
        animator.SetBool("KPress", kPress);
        animator.SetBool("IdleCrab", movement == Vector2.zero);
        animator.SetFloat("VelocidadCrabX", xSpeed);
        animator.SetFloat("VelocidadCrabY", ySpeed);
        animator.SetBool("Defend", isDefending);
        #endregion

        if (healthCrab <= 0)
        {
            animator.SetTrigger("Dead");
            healthBar.value = 0;
            playerController.enabled = false;
        }
    }

    private void HorizontalImputCheck()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void SpriteFlip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Contusion()
    {
        if (Input.GetKey(KeyCode.K) && isAttacking == false && isGrounded == true)
        {
            kPress = true;
        }
        else 
        {
            kPress = false;
        }
    }

    private void Pinch()
    {
        if (Input.GetKey(KeyCode.J) && isGrounded == true && isAttacking == false)
        {
            jPress = true;

        }
        else if (isAttacking)
        {
            jPress = false;
            _rbPlayer.velocity = new Vector2(0, 0);
        }
    }

    private void Twirl()
    {
        if (Input.GetKey(KeyCode.J) && isGrounded == false && isAttacking == false)
        {
            
            jAirPress = true;

        }
        else 
        {
            jAirPress = false;

        }
    }

    private void Drill()
    {
        if (Input.GetKey(KeyCode.K) && isGrounded == false && isAttacking == false)
        {

            kAirPress = true;

        }
        else if (isAttacking)
        {
            kAirPress = false;

        }
    }

    /*
    private void Steps()
    {
        if(Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.DownArrow))
        {
            
        }
    }
    */
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && currentJumps < posibleJumps && isAttacking == false && isGrounded == true && isDefending == false)
        {
            _rbSpeed = 0;
            _rbPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            _rbPlayer.gravityScale = 2f;
            currentJumps += 1;
        }
        else if (_rbSpeed == 0)
        {
            currentJumps = 0;
            isJumping = false;
        }
    }

    private void Defend()
    {
        if (Input.GetKeyDown(KeyCode.L) && isGrounded)
        {
            isDefending = true;
        }
        else if (Input.GetKeyUp(KeyCode.L) && isGrounded)
        {
            isDefending = false;
        }
    }


    private void AnimationTagCheck()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    public void TakeDamage()
    {
        healthCrab -= damageToTake;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
            
    }
    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
}

