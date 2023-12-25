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

    void Start()
    {
        canvas.enabled = false;
    }

    private void Update()
    {
        if (playerCollider != null && Input.GetKeyDown(KeyCode.E))
        {
            playerCollider.gameObject.GetComponent<Items>().AddItem(this);//���� ������ �����, �� �� ������ ��������� �������
            Destroy(gameObject); //�������� ������� � �����
            canvas.enabled = true;
            text.text = ReplicasClass.TextInsidials[this.index][0];
        }
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
}