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
    private bool isGrounded;

    public float yPosition;
    public GameObject objectToFollow;
    public Component transShadow;

    void Start()
    {
        transShadow = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transShadow.transform.position = new Vector2(objectToFollow.transform.position.x, yPosition);

        

        /*
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag(""))
        {
            horizontalInput = Input.GetAxisRaw("Horizontal"); //Detecta cuando pulsas las flechas Izquierda / Derecha

            transform.Translate(Vector2.right * Time.deltaTime * xSpeed * horizontalInput);
        }
        else
        {
            _rbShadow.velocity = Vector2.zero; //Esto hace que tenga sexo (velocida cero) por las noches ;) Postdata: Oli soy alvaro delagado y me follo a tu madre mientras hago este código lol xd omgealuñl
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

        [SerializeField] void OnCollisionEnter2D(Collision2D Player)
            {
            isGrounded = true;
            }
        [SerializeField] void OnCollisionExit2D(Collision2D Player)
            {
            isGrounded = false;
            }

        */

    /*
            verticalInput = Input.GetAxisRaw("Vertical"); //Detecta cuando pulsas las flechas Arriba / Abajo

            transform.Translate(Vector2.up * Time.deltaTime * xSpeed * verticalInput);
    */
}
}
