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

    private string timer;
    private string[] SplitTimer;
    private int hour = 0;

    void Start()
    {
        ReplicasClass.TextRandomLength = ReplicasClass.TextRandom.Length;
        ReplicasClass.TextHideLength = ReplicasClass.TextHide.Length;
        ReplicasClass.TextInsidialsLength = ReplicasClass.TextInsidials.Length;
        ReplicasClass.ReplLength = ReplicasClass.Repl0.Length;

        timer = time.text;
        SplitTimer = timer.Split();
        hour = Int32.Parse(SplitTimer[0]);

        canvas.enabled = false;        
    }

    void Update()
    {
        //≈сли врем€ такое-то
        if (hour>6 && hour <22 && hour%2==0) //Ёто условие надо будет потом изменить
        {
            canvas.enabled = true;
            text.text = ReplicasClass.TextRandom[UnityEngine.Random.Range(0, ReplicasClass.TextRandomLength)];
        }

        if (GetHided.isHided)
        {
            canvas.enabled = true;
            text.text = ReplicasClass.TextHide[UnityEngine.Random.Range(0, ReplicasClass.TextHideLength)];
        }

        //≈сли случилось сюжетное событие в виде подн€ти€ предмета
        if (Input.GetKeyDown(KeyCode.Alpha3)) //Ёто условие надо будет потом изменить
        {
            canvas.enabled = true;
            text.text = ReplicasClass.TextInsidials[UnityEngine.Random.Range(0, ReplicasClass.TextInsidialsLength)][0];
        }
    }

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