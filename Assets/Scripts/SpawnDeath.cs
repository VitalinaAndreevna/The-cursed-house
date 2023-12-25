using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnDeath : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public Transform[] spawnPoint;

    private bool canSpawn = true;
    private int randPoint;
    private float sanityPlank;
    public GameObject player;    
    
    void Update()
    {
        randPoint = Random.Range(0, spawnPoint.Length);
        sanityPlank = player.GameObject().GetComponent<PlayerScript>().sanity;
        Debug.Log(player.GameObject().GetComponent<PlayerScript>().sanity);

        if (sanityPlank <= 10 && canSpawn)
        {            
            Instantiate(enemyToSpawn, spawnPoint[randPoint].transform.position, Quaternion.identity);
            canSpawn = false;
        }
        else if (sanityPlank >= 40)
        {
            Destroy(enemyToSpawn);
            canSpawn = true;
        }
    }
}
