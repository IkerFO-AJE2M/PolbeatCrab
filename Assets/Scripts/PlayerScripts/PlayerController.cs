using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables Float
    public float horizontalInput;
    public float verticalInput;
    public float xSpeed;
    public float ySpeed;
    public float speedMultiplier;
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
        //Aplciamos el movimiento
        #region MOVEMENT
        horizontalInput = Input.GetAxisRaw("Horizontal"); //Detecta cuando pulsas las flechas Izquierda / Derecha

        transform.Translate(Vector2.right * Time.deltaTime * xSpeed * horizontalInput);

        verticalInput = Input.GetAxisRaw("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

        transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);
        #endregion

        animator.SetBool("IdleCrab", movement == Vector2.zero);
        /*
        horizontalInput = GetKeyDown(KeyCode.RightArrow); //Detecta cuando pulsas las flechas Izquierda / Derecha

        transform.Translate(Vector2.right * Time.deltaTime * xSpeed* horizontalInput);

        verticalInput = Input.GetAxis("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

        transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);
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
    } //Filpea el sprite en el eje X según el calor del horizontalInput
    
    /*
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //Detecta cuando pulsas 
        {
            xSpeed = 3;

            HorizontalImputCheck();

            transform.Translate(Vector2.right * Time.deltaTime * xSpeed);

            spriteRenderer.flipX = true; //Flipea el sprite
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            HorizontalImputCheck();

            transform.Translate(Vector2.left * Time.deltaTime * xSpeed);
            
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * ySpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        { 
            transform.Translate(Vector2.down * Time.deltaTime * ySpeed);
        }
       */
}

