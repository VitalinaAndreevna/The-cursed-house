using TMPro;
using UnityEngine;

public class Replicas : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI text;

    private string[] TextRandom = 
    {"��� ���� �� ��� ��������� � �����! � � ��� �� ����! ����� ��������� ���� ��� � ����� ��������� ������� ������",
    "� ���� ��� ������� ������, ����� �������� � ������������. ������� ������� � �������, ��������� ��� ��������",
    "��� ����� ��� - ���� ��������, ������� ������� � ������ ��������. �� ��� ����� �� ������ SMM-���������� � ������",
    "�����, ��� ��� �� ������ ����������� ���, ����� ����������� ������ ������ ��� ��������. ����� �������� �� ����",
    "��� �� �� ��� ���������, ���..."};
    
    private string[] TextHide =
    {"��� �� ����!? ��� ��� ����? ��� �� �������!",
    "�������, � ����� � ��� ��� ��� ������������..."};

    private string[] TextInsidials =
    {"�������, � ��� ���� �� ���� �������, ������������ ������� �� �� ���������",
    "��� ��� ������� � ���? � ���� �� �� ����� �������",
    "��� �� ��� ����� �������?"};

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
        //���� ����� �����-��
        if (Input.GetKeyDown(KeyCode.Alpha1)) //��� ������� ���� ����� ����� ��������
        {
            canvas.enabled = true;
            text.text = TextRandom[(int)(Random.Range(0, TextRandomLength))];
        }

        //���� ������ ������ isHided = True
        if (Input.GetKeyDown(KeyCode.Alpha2)) //��� ������� ���� ����� ����� ��������
        {
            canvas.enabled = true;
            text.text = TextHide[(int)(Random.Range(0, TextHideLength))];
        }

        //���� ��������� �������� ������� � ���� �������� ��������
        if (Input.GetKeyDown(KeyCode.Alpha3)) //��� ������� ���� ����� ����� ��������
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