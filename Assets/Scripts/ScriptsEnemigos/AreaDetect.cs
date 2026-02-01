using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetect : MonoBehaviour
{
    [SerializeField] FlyingEnemyCorrutine scriptFlyingEnemy;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        scriptFlyingEnemy.isIn = true;
        Debug.Log("Ayuda");
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        scriptFlyingEnemy.isIn = true;
        Debug.Log("Ayuda");
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        scriptFlyingEnemy.isIn = false;
        Debug.Log("Ayuda");
    }
}
