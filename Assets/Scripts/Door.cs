using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject activeCamera;
    public GameObject nextCamera;
    public Transform doorToOpen;
    public bool isOpen = true;

    public Transform GetDestination()
    {
        activeCamera.SetActive(false);
        nextCamera.SetActive(true);
        return doorToOpen;
    }
    public bool GetOpen()
    {
        return isOpen;
    }

    public void SetOpen(bool open)
    {
        isOpen = open;
    }
}