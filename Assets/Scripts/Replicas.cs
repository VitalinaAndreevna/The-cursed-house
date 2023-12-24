using TMPro;
using UnityEngine;

public class Replicas : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI text;

    private string[] TextRandom = 
    {"Мой друг не мог покончить с собой! Я в это не верю! Нужно осмотреть весь дом и найти настоящую причину смерти",
    "Я знал его слишком хорошо, чтобы поверить в самоубийство. Никаких проблем с законом, девушками или деньгами",
    "Его звали ИМЯ - душа компании, любимец девушек и просто красавец. Он был одним из лучших SMM-менеджеров в городе",
    "Боюсь, что мне не хватит оставшегося дня, чтобы прошерстить каждый уголок его особняка. Нужно остаться на ночь",
    "Чем же ты тут занимался, ИМЯ..."};
    
    private string[] TextHide =
    {"Что за чёрт!? Что это было? Это не человек!",
    "Кажется, я схожу с ума или это галлюцинации..."};

    private string[] TextInsidials =
    {"Кажется, у ИМЯ были от меня секреты, рассказывать которые он не собирался",
    "Как это связано с ИМЯ? Я пока не до конца понимаю",
    "Что же это может значить?"};

    private int TextRandomLength, TextHideLength, TextInsidialsLength;

    void Start()
    {
        TextRandomLength = TextRandom.Length;
        TextHideLength = TextHide.Length;
        TextInsidialsLength = TextInsidials.Length;
        canvas.enabled = false;
    }

    void Update()
    {
        //Если время такое-то
        if (Input.GetKeyDown(KeyCode.Alpha1)) //Это условие надо будет потом изменить
        {
            canvas.enabled = true;
            text.text = TextRandom[(int)(Random.Range(0, TextRandomLength))];
        }

        //Если статус игрока isHided = True
        if (Input.GetKeyDown(KeyCode.Alpha2)) //Это условие надо будет потом изменить
        {
            canvas.enabled = true;
            text.text = TextHide[(int)(Random.Range(0, TextHideLength))];
        }

        //Если случилось сюжетное событие в виде поднятия предмета
        if (Input.GetKeyDown(KeyCode.Alpha3)) //Это условие надо будет потом изменить
        {
            canvas.enabled = true;
            text.text = TextInsidials[(int)(Random.Range(0, TextInsidialsLength))];
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = false;
        }
    }
}