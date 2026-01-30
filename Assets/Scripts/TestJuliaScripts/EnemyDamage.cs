using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamage : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;

    void OnColliderEnter2D(BoxCollider2D EnemyDamage)
    {
        if(playerAtm.gameObject.tag == ("Player"))
        {
            enemyAtm.DealDamage(GameObject.FindGameObjectWithTag("Player"));
        }
      
    }
}
