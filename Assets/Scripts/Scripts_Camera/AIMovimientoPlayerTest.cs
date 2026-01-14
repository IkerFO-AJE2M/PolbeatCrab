using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D
    }

    void Update()
    {
        // Obtiene la entrada de movimiento (flechas o WASD)
        float moveX = Input.GetAxis("Horizontal"); // -1 a 1
        float moveY = Input.GetAxis("Vertical");   // -1 a 1

        // Calcula la dirección del movimiento
        Vector2 movement = new Vector2(moveX, moveY);

        // Aplica el movimiento al Rigidbody
        rb.velocity = movement * moveSpeed;
    }
}