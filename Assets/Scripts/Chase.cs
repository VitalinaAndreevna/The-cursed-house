using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject player;
    public GameObject start;
    public float speed;
    public float distanceBetween;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance < distanceBetween && !GetHided.isHided)       
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);        
        else        
            transform.position = Vector2.MoveTowards(this.transform.position, start.transform.position, speed * Time.deltaTime);        
    }
}
