using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isopen = false;

    public bool GetOpen()
    {
        return isopen;
    }

    public void SetOpen(bool open)
    {
        isopen = open;
    }
}
