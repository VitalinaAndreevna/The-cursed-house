using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingMonster : MonoBehaviour
{
    public bool isTriggered = false;
    public float speed;    
    public float changeTime = 3.0f;
    public float distanceBetween;
    public GameObject player;
    public GameObject start;   


    private float distance;
    private float timer;
    private int direction = 1;
    private Rigidbody2D mRB2D;
    

    void Start()
    {
        mRB2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;                        
        }
    }

    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (isTriggered && Vector2.Distance(transform.position, start.transform.position) == 0)
        {
            timer = changeTime / 2;
            isTriggered = false;
            direction = 1;
        }

        if (!isTriggered)
        {
            Vector2 position = mRB2D.position;
            position.x = position.x + Time.deltaTime * speed * direction;
            mRB2D.MovePosition(position);
        }

        if (distance < distanceBetween && !GetHided.isHided)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            isTriggered = true;
        }
        else if (isTriggered)
            transform.position = Vector2.MoveTowards(this.transform.position, start.transform.position, speed * Time.deltaTime);
    }
}
