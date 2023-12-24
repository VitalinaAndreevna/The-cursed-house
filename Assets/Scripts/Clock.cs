using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public int hour1, hour2, minute1, minute2, second;
    private float gameTime;
    private Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "" + hour1 + hour2 + ":" + minute1 + minute2;
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
