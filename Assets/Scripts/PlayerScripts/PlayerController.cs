using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables Float
    public float horizontalInput;
    public float verticalInput;
    public float baseSpeedX;
    public float baseSpeedY;
    public float xSpeed;
    public float ySpeed;
    public float speedMultiplierX;
    public float speedMultiplierY;
    public float umbralTiempo;
    private float TiempoCargado;
    // Varialbes Bool
    private bool jPress;
    private bool jHold;
    private bool isAttacking;
    //Variables de Componente
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    //Variables Compuestas
    private Vector2 movement;

    void Update()
    {

        //Cambiamos elvalor del Movement
        movement = new Vector2(horizontalInput, verticalInput);

        //Corregimos la orientación del sprite
        SpriteFlip();

        //Miramos si está atacando
        AnimationTagCheck();
        #region MOVEMENT.MODIFIERS
        //Nos aseguramos de que este pulsando o no el botón de correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            xSpeed = baseSpeedX * speedMultiplierX;
            ySpeed = baseSpeedY * speedMultiplierY;
        }
        else
        {
            xSpeed = baseSpeedX;
            ySpeed = baseSpeedY;
        }
        JAttack();



        #endregion

        //Aplicamos el movimiento
        #region MOVEMENT
        if (isAttacking == false)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal"); //Detecta cuando pulsas las flechas Izquierda / Derecha

            transform.Translate(Vector2.right * Time.deltaTime * xSpeed * horizontalInput);

            verticalInput = Input.GetAxisRaw("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

            transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);
        }

        #endregion

        animator.SetBool("Attack", isAttacking);
        animator.SetBool("JPress", jPress);
        animator.SetBool("JHold", jHold);
        animator.SetBool("IdleCrab", movement == Vector2.zero);
        animator.SetFloat("VelocidadCrabX", xSpeed);

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

    void JAttack()
    {
        umbralTiempo = 1f;
        TiempoCargado = Time.deltaTime;


        if (TiempoCargado > umbralTiempo)
        {
            Contusion();
        }
        else
        {
            Pinch();
        }
    }

    private void Contusion()
    {
        if (Input.GetKeyDown(KeyCode.J) && isAttacking == false)
        {
            jHold = true;
        }
        else
        {
            jHold = false;
        }
    }
    private void Pinch()
    {
        if (Input.GetKey(KeyCode.J) && isAttacking == false)
        {
            jPress = true;
            new WaitForSeconds(0.2f);
            if(spriteRenderer.flipX == true)
            {
                transform.Translate(new Vector2(0.01f, 0));
            }
            if (spriteRenderer.flipX == false)
            {
                transform.Translate(new Vector2(-0.01f, 0));
            }
        }
        else
        {
            jPress = false;
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

