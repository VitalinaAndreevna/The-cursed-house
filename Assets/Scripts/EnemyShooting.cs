using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float speed = 4.0f;
    public float changeTime = 3.0f;
    public float distanceBetween = 7.0f;

    public GameObject bullet;
    public Transform bulletPos;    

    private float timer;
    private float shootTimer;
    private int direction = 1;

    private GameObject player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

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

            if (shootTimer > 1.5f)
            {
                shootTimer = 0;
                Instantiate(bullet, bulletPos.position, Quaternion.identity);
            }
        }        
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        rb.MovePosition(position);
    }
}