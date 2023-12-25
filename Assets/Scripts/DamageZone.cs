using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damage = 5;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerScript controller = other.GetComponent<PlayerScript>();

            if (controller != null) 
            {
                controller.takeHit(damage);
            }
        }
    }
}
