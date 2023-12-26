using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKiller : MonoBehaviour
{
    public float speed = 0.5f;
    public int damage = 100;
    public PlayerScript player;

    private Rigidbody2D mRB2D;

    // Start is called before the first frame update
    void Start()
    {
        mRB2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().takeDeath();
        }
    }
}
