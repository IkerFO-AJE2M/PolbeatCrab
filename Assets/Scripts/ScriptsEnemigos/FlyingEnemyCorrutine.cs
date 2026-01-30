using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    [SerializeField] GameObject target;
    [SerializeField] Collider2D detectionRadious;
    [SerializeField] Animator flyerAnimation;

    //AnimatorVar
    private bool attacking;
    private bool idle;
    private bool death;
    private bool walking;

    // Start is called before the first frame update
    void Start()
    {
        playerPositionX = target.transform.position.x;
        playerPositionY = target.transform.position.y;
        enemyPositionX = transform.position.x;
        enemyPositionY = transform.position.y;
    }
    
    IEnumerator Attack()
    {
        float delay = 1f;
        yield return delay;
    }
    // Update is called once per frame
    void Update()
    {
        PositionData();

        if(toPlayerDistance >= 5f || toPlayerDistance <= -5f)
        {
            transform.Translate(new Vector2(toPlayerDistance, 0) * speedX * Time.deltaTime);
        }
    }

    void PositionData()
    {
        playerPositionX = target.transform.position.x;
        playerPositionY = target.transform.position.y;
        enemyPositionX = transform.position.x;
        enemyPositionY = transform.position.y;

        toPlayerDistance = playerPositionX - enemyPositionX;
    }
}
