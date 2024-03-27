using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public TextMeshProUGUI time;
    public GameObject[] monsters;

    public bool isNight;

    private string timer;
    private string[] SplitTimer;
    private int hour, minute;

    void Update()
    {
        timer = time.text;
        SplitTimer = timer.Split(':');
        if (SplitTimer[0][0] == '0')
            SplitTimer[0] = SplitTimer[0][1].ToString();
        if (SplitTimer[1][0] == '0')
            SplitTimer[1] = SplitTimer[1][1].ToString();
        hour = Int32.Parse(SplitTimer[0]);
        minute = Int32.Parse(SplitTimer[1]);

        //Если время такое-то
        if (hour > 6 && hour < 22) //Это условие надо будет потом изменить
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i].SetActive(false);
            }
            isNight = false;
        }
        else
        {
            isNight = true;
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i].SetActive(true);
            }
        }
    }
}
