using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Replicas : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI text;
    public TextMeshProUGUI time;

    public bool isShowHide, isShowRandom;

    private string timer;
    private string[] SplitTimer;
    private int hour, minute;

    public Animator animator;

    void Start()
    {
        //Получение количества фраз
        ReplicasClass.TextMorningLength = ReplicasClass.TextMorning.Length;
        ReplicasClass.TextEveningLength = ReplicasClass.TextEvening.Length;
        ReplicasClass.TextRandomLength = ReplicasClass.TextRandom.Length;
        ReplicasClass.TextHideLength = ReplicasClass.TextHide.Length;
        ReplicasClass.TextInsidialsLength = ReplicasClass.TextInsidials.Length;
        ReplicasClass.ReplLength = ReplicasClass.Repl0.Length;

        canvas.enabled = false; 
    }

    void Update()
    {

        //Получение текущего времени
        timer = time.text;
        SplitTimer = timer.Split(':');
        if (SplitTimer[0][0] == '0')
            SplitTimer[0] = SplitTimer[0][1].ToString();
        if (SplitTimer[1][0] == '0')
            SplitTimer[1] = SplitTimer[1][1].ToString();
        hour = Int32.Parse(SplitTimer[0]);
        minute = Int32.Parse(SplitTimer[1]);

        //Если наступило утро
        if (hour == 6 && minute == 10)
        {
            canvas.enabled = true;
            text.text = ReplicasClass.TextMorning[UnityEngine.Random.Range(0, ReplicasClass.TextMorningLength)];
        }

        //Если наступила ночь
        if (hour == 22 && minute == 10)
        {
            canvas.enabled = true;
            text.text = ReplicasClass.TextEvening[UnityEngine.Random.Range(0, ReplicasClass.TextEveningLength)];
        }

        //Случайные фразы в течение дня
        if (hour > 6 && hour < 22 && hour % 2 == 0 && minute == 0 && !isShowRandom)
        {
            canvas.enabled = true;
            text.text = ReplicasClass.TextRandom[UnityEngine.Random.Range(0, ReplicasClass.TextRandomLength)];
            isShowRandom = true;
        }
        else if (minute != 0 && isShowRandom)
        {
            isShowRandom = false;
        }

        //Когда персонаж спрятался
        if (GetHided.isHided && !isShowHide)
        {
            canvas.enabled = true;
            text.text = ReplicasClass.TextHide[UnityEngine.Random.Range(0, ReplicasClass.TextHideLength)];
            isShowHide  = true;
        }
        else if (!GetHided.isHided && isShowHide)
        {
            canvas.enabled = false;
            isShowHide = false;
        }



        animator.SetBool("IsVisible", canvas.enabled);
    }

    //Функция для кнопки
    public void NextReplicas()
    {
        if (ReplicasClass.TextRandom.Contains(text.text))
        {
            canvas.enabled = false;
        }

        else
        {
            if (ReplicasClass.TextHide.Contains(text.text))
            {
                canvas.enabled = false;
            }

            else
            {
                for (int i = 0; i < ReplicasClass.TextInsidialsLength; i++)
                {
                    if (ReplicasClass.TextInsidials[i].Contains(text.text))
                    {
                        int index = Array.IndexOf(ReplicasClass.TextInsidials[i], text.text);
                        if (index < ReplicasClass.ReplLength - 1)
                        {
                            text.text = ReplicasClass.TextInsidials[i][index + 1];
                        }
                        else
                        {
                            canvas.enabled = false;
                        }

                    }
                }
            }
        }
    }
}