using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Slot : MonoBehaviour
{
    public Image icon; //Иконка, куда будет прикрепляться спрайт
    public int id;
    //private Items items;

    public void UpdateSlot(Sprite sprite) //Обновление слота
    {
        icon.sprite = sprite;
    }
}