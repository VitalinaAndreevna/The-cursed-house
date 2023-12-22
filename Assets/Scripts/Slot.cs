using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Slot : MonoBehaviour
{
    public Image icon; //������, ���� ����� ������������� ������
    public int id;
    //private Items items;

    public void UpdateSlot(Sprite sprite) //���������� �����
    {
        icon.sprite = sprite;
    }
}