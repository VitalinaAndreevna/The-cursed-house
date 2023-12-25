using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = true;

    public bool GetOpen()
    {
        return isOpen;
    }

    public void SetOpen(bool open)
    {
        isOpen = open;
    }
}