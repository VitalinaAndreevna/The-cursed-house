using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventManage : MonoBehaviour
{
    public TextMeshProUGUI time;

    public bool isShow;

    private string timer;
    private string[] SplitTimer;
    private int hour, minute;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        }
    }
}
