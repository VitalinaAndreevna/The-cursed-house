using System;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public int hour1, hour2, minute1, minute2, second;
    private float gameTime;
    private TextMeshProUGUI myText;
    public GameObject[] monsters;

    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        myText.text = "" + hour1 + hour2 + ":" + minute1 + minute2;
        changeTime();
        if(getHours() > 6 && getHours() < 22)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i].SetActive(false);
            }
        }
        else
        {
            Debug.Log(getHours());
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i].SetActive(true);
            }
        }
    }

    public int getHours()
    {
        string hours = hour1.ToString() + hour2.ToString();
        return Int32.Parse(hours);
    }

    public void changeTime()
    {
        gameTime += 30 * Time.deltaTime;
        if (gameTime > 1)
        {
            second += 1;
            gameTime = 0;
        }
        if (second > 59)
        {
            minute2 += 1;
            second = 0;
        }
        if (minute2 > 9)
        {
            minute1 += 1;
            minute2 = 0;
        }
        if (minute1 > 5)
        {
            hour2 += 1;
            minute1 = 0;
        }
        if (hour2 > 9)
        {
            hour1 += 1;
            hour2 = 0;
        }
        if (hour1 == 2 && hour2 > 3)
        {
            hour1 = 0;
            hour2 = 0;
        }
    }
}