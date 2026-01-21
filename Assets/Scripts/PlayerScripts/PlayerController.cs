using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalInput;
    public float verticalInput;
    public float xSpeed;
    public float ySpeed;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        #region MOVEMENT
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //Detecta cuando pulsas 
        {
            animator.VelodadAnimacionX

            transform.Translate(Vector2.right * Time.deltaTime * xSpeed);

            spriteRenderer.flipX = true; //Flipea el sprite
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
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
        #endregion

        /*
        horizontalInput = GetKeyDown(KeyCode.RightArrow); //Detecta cuando pulsas las flechas Izquierda / Derecha

        transform.Translate(Vector2.right * Time.deltaTime * xSpeed* horizontalInput);

        verticalInput = Input.GetAxis("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

        transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);
        */
    }
}
