using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Varialbes Bool
    private bool jPress;
    private bool jHold;
    private bool isAttacking;
    private bool isCharge;
    private bool isJumping;
    private bool isGrounded;
    //Variables de Componente
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D _rbPlayer;
    [SerializeField] LayerMask Ground;
    //Variables Compuestas
    private Vector2 movement;

    void Start()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        

        //Actualizamos la velocidad del Rigidbody cada frame
        _rbSpeed = _rbPlayer.velocity.magnitude;

        //Cambiamos elvalor del Movement
        movement = new Vector2(horizontalInput, 0f);

        //Corregimos la orientación del sprite
        SpriteFlip();

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


        #endregion

        //Aplicamos el movimiento
        #region MOVEMENT
        if (isAttacking == false)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal"); //Detecta cuando pulsas las flechas Izquierda / Derecha

            transform.Translate(Vector2.right * Time.deltaTime * xSpeed * horizontalInput);

           /* verticalInput = Input.GetAxisRaw("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

            transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);
           */
        }

        #endregion

        #region AnimatorBools
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("Jump", isJumping);
        animator.SetBool("Attack", isAttacking);
        animator.SetBool("Charge", isCharge);
        animator.SetBool("JPress", jPress);
        animator.SetBool("JHold", jHold);
        animator.SetBool("IdleCrab", movement == Vector2.zero);
        animator.SetFloat("VelocidadCrabX", xSpeed);
        animator.SetFloat("VelocidadCrabY", ySpeed);
        #endregion

        /*horizontalInput = Input.GetAxisRaw("Horizontal"); //Detecta cuando pulsas las flechas Izquierda / Derecha

         transform.Translate(Vector2.right * Time.deltaTime * xSpeed * horizontalInput);

         verticalInput = Input.GetAxisRaw("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

         transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);
         #endregion

         animator.SetBool("IdleCrab", movement == Vector2.zero);
         animator.SetFloat("VelocidadCrabX", xSpeed);
        */
    }

    private void HorizontalImputCheck()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void SpriteFlip()
    {
        if (horizontalInput > 0.01)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < -0.01)
        {
            spriteRenderer.flipX = false;
        }
    }
    /*
    void JAttack()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            umbralTiempo = 1f;
            TiempoCargado = Time.deltaTime;
            isCharge = true;

            if(isAttacking == true)
            {
                if (TiempoCargado > umbralTiempo && isCharge == true)
                {
                    Contusion();
                }
                else
                {
                    Pinch();
                }
            }
        }
        
            
    }

    private void Contusion()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            jHold = true;
        }
        else
        {
            jHold = false;
        }
    }*/
    private void Pinch()
    {
        if (Input.GetKey(KeyCode.J) && isAttacking == false)
        {
            _rbPlayer.AddForce(Vector2.right * horizontalInput * jumpForce, ForceMode2D.Impulse);
            jPress = true;

        }
        else if (isAttacking)
        {
            jPress = false;
            _rbPlayer.velocity = new Vector2(0, 0);
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
                _rbSpeed = 0;
                _rbPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                _rbPlayer.gravityScale = 2f;
                currentJumps += 1;
        }
        else if (_rbSpeed == 0)
        {
            _rbPlayer.gravityScale = 0f;
            isJumping = false;
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
}

