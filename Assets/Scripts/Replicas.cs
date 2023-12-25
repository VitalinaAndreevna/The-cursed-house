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
        "��� ���� �� ��� ��������� � �����! � � ��� �� ����! ����� ��������� ���� ��� � ����� ��������� ������� ������",
        "� ���� ��� ������� ������, ����� �������� � ������������. ������� ������� � �������, ��������� ��� ��������",
        "��� ����� ��� - ���� ��������, ������� ������� � ������ ��������. �� ��� ����� �� ������ SMM-���������� � ������",
        "�����, ��� ��� �� ������ ����������� ���, ����� ����������� ������ ������ ��� ��������. ����� �������� �� ����",
        "��� �� �� ��� ���������, ���..."
    };
    
    private string[] TextHide =
    {
        "��� �� ����!? ��� ��� ����? ��� �� �������!",
        "�������, � ����� � ��� ��� ��� ������������..."
    };

    static string[] Repl0 = 
    {
        "�������, � ��� ���� �� ���� �������, ������������ ������� �� �� ���������",
        "��� ��� ������� � ���? � ���� �� �� ����� �������",
        "��� �� ��� ����� �������?"
    };
    static string[] Repl1 = 
    {
        "2 ����� ������ - 1",
        "2 ����� ������ - 2",
        "2 ����� ������ - 3"
    };
    static string[] Repl2 = 
    {
        "3 ����� ������ - 1",
        "3 ����� ������ - 2",
        "3 ����� ������ - 3"
    };
    static string[] Repl4 = 
    {
        "4 ����� ������ - 1",
        "4 ����� ������ - 2",
        "4 ����� ������ - 3"
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
        //���� ����� �����-��
        if (Input.GetKeyDown(KeyCode.Alpha1)) //��� ������� ���� ����� ����� ��������
        {
            canvas.enabled = true;
            text.text = TextRandom[UnityEngine.Random.Range(0, TextRandomLength)];
        }

        //���� ������ ������ isHided = True
        if (Input.GetKeyDown(KeyCode.Alpha2)) //��� ������� ���� ����� ����� ��������
        {
            canvas.enabled = true;
            text.text = TextHide[UnityEngine.Random.Range(0, TextHideLength)];
        }

        //���� ��������� �������� ������� � ���� �������� ��������
        if (Input.GetKeyDown(KeyCode.Alpha3)) //��� ������� ���� ����� ����� ��������
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