using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float distanceBetween;
    public float changeTime;
    public float speed;
    public GameObject bullet;
    public Transform bulletPos;    

    private float timer;
    private float shootTimer;
    private int direction = 1;
    private GameObject player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween && !GetHided.isHided)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer > 2)
            {
                shootTimer = 0;
                shoot();
            }
        }        
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        rb.MovePosition(position);
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
