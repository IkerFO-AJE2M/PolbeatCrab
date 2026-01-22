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
    // Varialbes Bool
    private bool JPress;
    private bool IsAtacking;
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

        Pinch();

        #endregion

        //Aplciamos el movimiento
        #region MOVEMENT
        horizontalInput = Input.GetAxisRaw("Horizontal"); //Detecta cuando pulsas las flechas Izquierda / Derecha

        transform.Translate(Vector2.right * Time.deltaTime * xSpeed * horizontalInput);

        verticalInput = Input.GetAxisRaw("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

        transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);


        #endregion

        animator.SetBool("JPress", JPress);
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
    
    private void Pinch()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            JPress = true;
        }
        else
        {
            JPress = false;
        }
    }

    //Filpea el sprite en el eje X según el calor del horizontalInput

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

    /*
 protected override void FixedUpdate()
 {
     base.FixedUpdate();

     foreach (Collider2D groundCollider in groundColliders)
     {
         if (groundCollider != null)
         {
             Physics2D.IgnoreCollision(groundCollider, player.collider, player.orthogonalRigidbody.localPosition.z >= groundCollider.transform.position.z);
         }
     }
 }
 */
}

