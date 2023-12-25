using System;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int index;
    public string itemName;
    public string itemDesc;

    Collider2D playerCollider;

    public Canvas canvas;
    public TextMeshProUGUI text;

    private EventManager eventManager;

    void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        canvas.enabled = false;
    }

    private void Update()
    {
        if (!eventManager.isNight)
            Find();
        //����� ��������� ��� ������
    }

    void OnTriggerEnter2D(Collider2D other) //������ �� ������
    {
        if (other.transform.tag == "Player")
        { 
            playerCollider = other; // ��������� ��������� ������
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerCollider)
        { 
            playerCollider = null; // ���������� ��������� ������� ��� ������ �� ����
        }
    }

    private void Find()
    {
        if (playerCollider != null && Input.GetKeyDown(KeyCode.E))
        {
            playerCollider.gameObject.GetComponent<Items>().AddItem(this);
            Destroy(gameObject);
            canvas.enabled = true;
            text.text = ReplicasClass.TextInsidials[this.index][0];
        }
    }
}