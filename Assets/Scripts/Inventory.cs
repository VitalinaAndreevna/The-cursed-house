using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Canvas canvas;
    public GameObject player;
    private Items items;
    public Transform inventorySlots;
    private Slot[] slots;
    public GameObject Inspection;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        items = player.GetComponent<Items>();
        slots = inventorySlots.GetComponentsInChildren<Slot>(); //Получение всех ячеек
        Inspection.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Inspection.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        { 
            Inspection.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.I))
        { 
            canvas.enabled = !canvas.enabled;
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++) //Проверка всех предметов
        {
            if (items.getBools()[i]) //Если такой предмет есть у пользователя, то он будет отображаться в слоте
            {
                slots[i].UpdateSlot(items.getSprites()[i]);
                int local = i;
                Button tempButton = slots[i].GetComponent<Button>();
                tempButton.onClick.AddListener(delegate { SelectObject(local); });
            }
            else
            {
                slots[i].UpdateSlot(null);
            }
        }
    }

    public void SelectObject(int id)
    {
        Inspection.gameObject.SetActive(true);
        Image[] images = Inspection.GetComponentsInChildren<Image>();
        images[1].sprite = slots[id].icon.sprite;
        Text[] texts = Inspection.GetComponentsInChildren<Text>();
        if (texts.Length >= 2)
        {
            Text text1 = texts[0];
            Text text2 = texts[1];

            text1.text = items.getItems()[id].itemName;
            text2.text = items.getItems()[id].itemDesc;
        }
    }
}