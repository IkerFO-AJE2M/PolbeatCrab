using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamage : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;

    private void OnCollisionEnter2D(Collision2D EnemyDamage)
    {
        if(EnemyDamage.gameObject.tag == ("Player"))
        {
            enemyAtm.DealDamage(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}
