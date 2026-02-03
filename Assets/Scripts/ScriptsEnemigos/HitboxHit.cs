using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitboxHit : MonoBehaviour
{
    public PlayerControllerCarril playerController;
    public EnemigoAvanzado enemyController;
    public int damageEnemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("me cago");
            playerController.TakeDamage(damageEnemy);
        }
    }
}
