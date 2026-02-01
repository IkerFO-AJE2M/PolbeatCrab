using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FlyingEnemyCorrutine : MonoBehaviour
{

    public float speedX;
    public float speedY;
    public float playerPositionX;
    public float playerPositionY;
    public float enemyPositionX;
    public float enemyPositionY;
    public float toPlayerDistance;
    public float diveSpeed;
    public float retreveSpeed;

    [SerializeField] GameObject target;
    [SerializeField] Collider2D detectionRadious;
    [SerializeField] Animator flyerAnimation;

    //AnimatorVar
    private bool attacking;
    private bool idle;
    private bool death;
    private bool walking;
    
    void Start()
    {

    }

    void Update()
    {
        PositionData();
        if (toPlayerDistance < 10f)
        {
            speedX = 3;
            playerPositionY = target.transform.position.y;
            enemyPositionY = transform.position.y;
            if (toPlayerDistance > 5f)
            {
                MoveToTarget();
            }
            else
            {
                StartCoroutine(AttackDive());
            }
        }
        else
        {
            speedX = 0;
        }

    }
     
    IEnumerator AttackDive()
    {
        if (toPlayerDistance < 6f)
        {
            yield return new WaitForSeconds(1f);
            PositionData();
            while (toPlayerDistance > 1.65f)
            {
                Debug.Log("Drivin'");
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, diveSpeed * Time.deltaTime);
                yield return null;
            }

            while (toPlayerDistance < 5.9f)
            {
                Debug.Log("Retreavin");
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, retreveSpeed * Time.deltaTime * -1f);
                yield return null;
            }

            yield return new WaitForSeconds(2f);
        }
        else
        {
            yield break;
        }


    }

    void MoveToTarget()
    {
        if(playerPositionX < enemyPositionX)
        {
            transform.Translate(Vector2.left * speedX * Time.deltaTime);
        }

        if (playerPositionX > enemyPositionX)
        {
            transform.Translate(Vector2.left * speedX * Time.deltaTime * -1);
        }
    }

    void PositionData()
    {
        playerPositionX = target.transform.position.x;
        playerPositionY = target.transform.position.y;
        enemyPositionX = transform.position.x;
        enemyPositionY = transform.position.y;

        toPlayerDistance = Vector2.Distance(target.transform.position, transform.position);
    }
}
