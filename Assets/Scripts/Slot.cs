using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon; 
    public int id;

    public void UpdateSlot(Sprite sprite) //���������� �����
    {
        icon.sprite = sprite;
    }
}