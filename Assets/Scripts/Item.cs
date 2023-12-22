using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

[System.Serializable]

public class Item : MonoBehaviour
{
    public int index;
    public string itemName;
    public string itemDesc;

    Collider2D playerCollider;
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
    private void Start()
    {
        Button tempButton = this.GetComponent<Button>();
        tempButton.onClick.AddListener(delegate { SelectObject(); });
    }

    public void SelectObject()
    {
        if (playerCollider != null)
        {
            playerCollider.gameObject.GetComponent<Items>().AddItem(this);//���� ������ �����, �� �� ������ ��������� �������
            Destroy(gameObject); //�������� ������� � �����
        }
    }
}