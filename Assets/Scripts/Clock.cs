using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public int hour1, hour2, minute1, minute2, second;
    private float gameTime;
    private TextMeshProUGUI myText;

    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

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