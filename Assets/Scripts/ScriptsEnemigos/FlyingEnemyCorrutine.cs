using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using Unity.Collections;
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
    private Vector2 movement;
    private bool _facingRight;



    [SerializeField] GameObject target;
    [SerializeField] Collider2D detectionRadious;
    [SerializeField] Animator flyerAnimation;
    [SerializeField] Rigidbody2D _flyerRB;

    //AnimatorVar
    private bool attacking;
    private bool idle;
    private bool death;
    private bool isDiving;
    private bool walking;
    private bool isRetreaving;

    void Start()
    {

    }

    void Update()
    {
        Flip();

        movement = Vector2.zero;

        PositionData();
        if (toPlayerDistance < 10f)
        {
            isDiving = false;
            isRetreaving = false;
            walking = true;
            speedX = 3;
            playerPositionY = target.transform.position.y;
            enemyPositionY = transform.position.y;
            if (toPlayerDistance > 5f)
            {
                MoveToTarget();
            }
            else
            {
                walking = false;
                StartCoroutine(AttackDive());
            }
        }
        else
        {
            speedX = 0;
        }

        flyerAnimation.SetBool("Walking", walking);


    }

    private void Flip()
    {
        if (enemyPositionX < playerPositionX && _facingRight == true)
        {
            SpriteFlip();
        }
        else if (enemyPositionX > playerPositionX && _facingRight == false)
        {
            SpriteFlip();
        }
    }

    IEnumerator AttackDive()
    {
        if (toPlayerDistance < 6f)
        {
            yield return new WaitForSeconds(1f);
            PositionData();
            while (toPlayerDistance > 2.5f)
            {
                attacking = true;
                Debug.Log("Drivin'");
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, diveSpeed * Time.deltaTime);
                isDiving = true;
                isRetreaving = false;
                flyerAnimation.SetBool("Attack", isDiving);
                yield return null;
            }

            attacking = false;

            while (toPlayerDistance < 7f && attacking == false)
            {
                Debug.Log("Retreavin");
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, retreveSpeed * Time.deltaTime * -1f);
                isRetreaving = true;
                isDiving = false;
                flyerAnimation.SetBool("Retreve", isRetreaving);
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
    private void SpriteFlip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
