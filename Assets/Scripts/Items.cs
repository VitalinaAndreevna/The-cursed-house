using UnityEngine;

public class Items : MonoBehaviour
{
    private Inventory inventory; // Добавьте ссылку на объект Inventory
    private bool[] hasItems; //Наличие предметов
    private Sprite[] Sprites; //Наличие предметов
    private Item[] itemsEl; //Наличие предметов

    void Start()
    {
        inventory = FindObjectOfType<Inventory>(); // Находит объект Inventory в сцене
        int x = inventory.inventorySlots.GetComponentsInChildren<Slot>().Length;
        hasItems = new bool[x];
        Sprites = new Sprite[x];
        itemsEl = new Item[x];
        for (int i = 0; i < x; i++)
        {
            itemsEl[i] = null;
            Sprites[i] = null;
            hasItems[i] = false;
        }
    }

    public Sprite[] getSprites()
    {
        return Sprites;
    }

    public bool[] getBools()
    {
        return hasItems;
    }

    public Item[] getItems()
    {
        return itemsEl;
    }

    public void AddItem(Item item)
    {
        hasItems[item.index] = true; //Добавление предмета при подборе
        Sprites[item.index] = item.GetComponent<SpriteRenderer>().sprite;
        itemsEl[item.index] = item;
    }
}