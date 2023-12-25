using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Replicas : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI text;

    private string[] TextRandom = 
    {
        "Мой друг не мог покончить с собой! Я в это не верю! Нужно осмотреть весь дом и найти настоящую причину смерти",
        "Я знал его слишком хорошо, чтобы поверить в самоубийство. Никаких проблем с законом, девушками или деньгами",
        "Его звали ИМЯ - душа компании, любимец девушек и просто красавец. Он был одним из лучших SMM-менеджеров в городе",
        "Боюсь, что мне не хватит оставшегося дня, чтобы прошерстить каждый уголок его особняка. Нужно остаться на ночь",
        "Чем же ты тут занимался, ИМЯ..."
    };
    
    private string[] TextHide =
    {
        "Что за чёрт!? Что это было? Это не человек!",
        "Кажется, я схожу с ума или это галлюцинации..."
    };

    static string[] Repl0 = 
    {
        "Кажется, у ИМЯ были от меня секреты, рассказывать которые он не собирался",
        "Как это связано с ИМЯ? Я пока не до конца понимаю",
        "Что же это может значить?"
    };
    static string[] Repl1 = 
    {
        "2 набор реплик - 1",
        "2 набор реплик - 2",
        "2 набор реплик - 3"
    };
    static string[] Repl2 = 
    {
        "3 набор реплик - 1",
        "3 набор реплик - 2",
        "3 набор реплик - 3"
    };
    static string[] Repl4 = 
    {
        "4 набор реплик - 1",
        "4 набор реплик - 2",
        "4 набор реплик - 3"
    };

    private string[][] TextInsidials = {Repl0, Repl1, Repl2, Repl4};

    private int TextRandomLength, TextHideLength, TextInsidialsLength, ReplLength;

    void Start()
    {
        TextRandomLength = TextRandom.Length;
        TextHideLength = TextHide.Length;
        TextInsidialsLength = TextInsidials.Length;
        ReplLength = Repl0.Length;

        canvas.enabled = false;        
    }

    void Update()
    {
        //Если время такое-то
        if (Input.GetKeyDown(KeyCode.Alpha1)) //Это условие надо будет потом изменить
        {
            canvas.enabled = true;
            text.text = TextRandom[UnityEngine.Random.Range(0, TextRandomLength)];
        }

        //Если статус игрока isHided = True
        if (Input.GetKeyDown(KeyCode.Alpha2)) //Это условие надо будет потом изменить
        {
            canvas.enabled = true;
            text.text = TextHide[UnityEngine.Random.Range(0, TextHideLength)];
        }

        //Если случилось сюжетное событие в виде поднятия предмета
        if (Input.GetKeyDown(KeyCode.Alpha3)) //Это условие надо будет потом изменить
        {
            canvas.enabled = true;
            text.text = TextInsidials[UnityEngine.Random.Range(0, TextInsidialsLength)][0];
        }

    }

    public void NextReplicas()
    {
        if (TextRandom.Contains(text.text))
        {
            canvas.enabled = false;
        }

        else
        {
            if (TextHide.Contains(text.text))
            {
                canvas.enabled = false;
            }

            else
            {
                for (int i = 0; i < TextInsidialsLength; i++)
                {
                    if (TextInsidials[i].Contains(text.text))
                    {
                        int index = Array.IndexOf(TextInsidials[i], text.text);
                        if (index < ReplLength - 1)
                        {
                            text.text = TextInsidials[i][index + 1];
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