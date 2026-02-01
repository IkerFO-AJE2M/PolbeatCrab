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
    public bool isIn;
    

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        playerPositionX = target.transform.position.x;
        playerPositionY = target.transform.position.y;
        enemyPositionX = transform.position.x;
        enemyPositionY = transform.position.y;
        PositionData();
        StartCoroutine(AttackDive());
    }
     
    IEnumerator AttackDive()
    {


            while (Mathf.Abs(toPlayerDistance) > 5f)
            {
                Debug.Log("Movin'");
                MoveToTarget();
            
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (Mathf.Abs(toPlayerDistance) > 1.65f && Mathf.Abs(toPlayerDistance) < 5f)
            {
                Debug.Log("Drivin'");
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, diveSpeed * Time.deltaTime);
                yield return null;  
            }

            while (Mathf.Abs(toPlayerDistance) < 5f)
            {
                Debug.Log("Retreavin");
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, retreveSpeed * Time.deltaTime * -1f);
                yield return null;
            }

            yield return new WaitForSeconds(2f);

    }

    void MoveToTarget()
    {
        if(toPlayerDistance > 1)
        {
            transform.Translate(new Vector2(target.transform.position.x, 0f) * speedX * Time.deltaTime);
        }

        if (toPlayerDistance < 1)
        {
            transform.Translate(new Vector2(target.transform.position.x, 0f) * speedX * Time.deltaTime * -1);
        }
    }

    void PositionData()
    {
        playerPositionX = target.transform.position.x;
        playerPositionY = target.transform.position.y;
        enemyPositionX = transform.position.x;
        enemyPositionY = transform.position.y;

        //toPlayerDistance = Vector2.Distance(new Vector2(playerPositionX, playerPositionY), new Vector2(enemyPositionX, enemyPositionY));
        toPlayerDistance = Vector2.Distance(target.transform.position, transform.position);
    }
}
