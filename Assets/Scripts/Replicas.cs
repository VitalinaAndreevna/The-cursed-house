using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Replicas : MonoBehaviour
{
    
    public Canvas canvas;
    public TextMeshProUGUI text;
    static string[] TextRandom = 
    {"��� ���� �� ��� ��������� � �����! � � ��� �� ����! ����� ��������� ���� ��� � ����� ��������� ������� ������",
    "� ���� ��� ������� ������, ����� �������� � ������������. ������� ������� � �������, ��������� ��� ��������",
    "��� ����� ��� - ���� ��������, ������� ������� � ������ ��������. �� ��� ����� �� ������ SMM-���������� � ������",
    "�����, ��� ��� �� ������ ����������� ���, ����� ����������� ������ ������ ��� ��������. ����� �������� �� ����",
    
    "��� �� �� ��� ���������, ���..."};
    int TextRandomLength = TextRandom.Length;

    static string[] TextHide =
    {"��� �� ����!? ��� ��� ����? ��� �� �������!",
    "�������, � ����� � ��� ��� ��� ������������..."};
    int TextHideLength = TextHide.Length;

    static string[] TextInsidials =
    {"�������, � ��� ���� �� ���� �������, ������������ ������� �� �� ���������",
    "��� ��� ������� � ���? � ���� �� �� ����� �������",
    "��� �� ��� ����� �������?"};
    int TextInsidialsLength = TextInsidials.Length;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //���� ����� �����-��
        if (Input.GetKeyDown(KeyCode.Alpha1)) //��� ������� ���� ����� ����� ��������
        {
            canvas.enabled = true;
            text.text = TextRandom[(int)(Random.Range(0, TextRandomLength))];
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canvas.enabled = false;
            }
        }

        //���� ������ ������ isHided = True
        if (Input.GetKeyDown(KeyCode.Alpha2)) //��� ������� ���� ����� ����� ��������
        {
            canvas.enabled = true;
            text.text = TextHide[(int)(Random.Range(0, TextHideLength))];
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canvas.enabled = false;
            }
        }

        //���� ��������� �������� ������� � ���� �������� ��������
        if (Input.GetKeyDown(KeyCode.Alpha3)) //��� ������� ���� ����� ����� ��������
        {
            canvas.enabled = true;
            text.text = TextInsidials[(int)(Random.Range(0, TextInsidialsLength))];
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canvas.enabled = false;
            }
        }

    }
}
