using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFollow : MonoBehaviour
{
    public float horizontalInput;
  //  public float verticalInput;
    public float baseSpeedX;
    public float baseSpeedY;
    public float xSpeed;
    public float ySpeed;
    public float speedMultiplierX;
    public float speedMultiplierY;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D _rbShadow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag(""))
        {
            horizontalInput = Input.GetAxisRaw("Horizontal"); //Detecta cuando pulsas las flechas Izquierda / Derecha

            transform.Translate(Vector2.right * Time.deltaTime * xSpeed * horizontalInput);
        }
        else
        {
            _rbShadow.velocity = Vector2.zero;
        }

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


            

       
/*
        verticalInput = Input.GetAxisRaw("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

        transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);
*/
    }
}
