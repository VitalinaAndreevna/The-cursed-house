using UnityEngine;

public class Item : MonoBehaviour
{
    public int index;
    public string itemName;
    public string itemDesc;

    Collider2D playerCollider;

    private void Update()
    {
        if (playerCollider != null && Input.GetKeyDown(KeyCode.E))
        {
            playerCollider.gameObject.GetComponent<Items>().AddItem(this);//Если наехал игрок, то он сможет подобрать предмет
            Destroy(gameObject); //Удаление объекта с карты
        }
    }

    void OnTriggerEnter2D(Collider2D other) //«Наезд» на объект
    {
        if (other.transform.tag == "Player")
        { 
            playerCollider = other; // Сохраняем коллайдер игрока
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerCollider)
        { 
            playerCollider = null; // Сбрасываем коллайдер укрытия при выходе из него
        }
    }
}