using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject dialogBox; //Сообщение для игрока


    void Start()
    {
        dialogBox.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogBox.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interaction();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogBox.SetActive(false);
    }

    private void Interaction()
    {
        if (this.tag == "Item")
        {
            //Поместить предмет в инвентарь

        }
    }
}
