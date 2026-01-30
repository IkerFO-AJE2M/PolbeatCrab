using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class FlyingEnemyCorrutine : MonoBehaviour
{

    public float speedX;
    public float speedY;
    [SerializeField] GameObject target;
    [SerializeField] Collider2D detectionRadious;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetect();
    }

    void PlayerDetect()
    {
        if (detectionRadious.isTrigger == true);
        Debug.Log("chupame el guebo");
    }
}
