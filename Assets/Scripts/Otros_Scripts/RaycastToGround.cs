using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToGround : MonoBehaviour
{
    private RaycastHit2D groundHit;
    [SerializeField] LayerMask Ground;

    // Start is called before the first frame update
    void Start()
    {
        groundHit = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, Ground);
    }

    // Update is called once per frame
    void Update()
    {
        if (groundHit == true)
        {

        }
    }
}
