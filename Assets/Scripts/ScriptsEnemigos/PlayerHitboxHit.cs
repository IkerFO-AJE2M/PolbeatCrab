using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxHit : MonoBehaviour
{
   // public PlayerControllerCarril controller;
    public EnemigoAvanzado cucaracho;
    public int damagePlayer;
    // Start is called before the first frame update
    void Start()
    {
      //  controller = GetComponent<PlayerControllerCarril>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("me cago");
            cucaracho.ReciveDamage(damagePlayer);
        }
    }
}
