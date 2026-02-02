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
        transform.localPosition = new Vector2(objectToFollow.transform.localPosition.x, yPosition);
    }
}

