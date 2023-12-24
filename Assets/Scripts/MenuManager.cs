using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //������ � ������������
using UnityEngine.SceneManagement; //������ �� �������
using UnityEngine.Audio; //������ � �����


public class MenuManager : MonoBehaviour
{
    public bool isOpened = false; //������� �� ����
    public float volume = 50; //���������
    public bool isFullscreen = false; //������������� �����

    public Slider audioMixer; //��������� ���������

    public Dropdown resolutionDropdown; //������ � ������������ ��� ����
    private Resolution[] resolutions; //������ ��������� ����������
    private int currResolutionIndex = 0; //������� ����������

    public Canvas MainMenu; 
    public Canvas SettingsMenu;

    void Start()
    {
        SettingsMenu.enabled = isOpened;
    }

    void Update()
    {   
        if (isOpened && Input.GetKey(KeyCode.Escape))
        {
            ShowHideMenu();
        }
    }

    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        SettingsMenu.enabled = isOpened; //��������� ��� ���������� Canvas.
        MainMenu.enabled = !isOpened;
    }

    public void ChangeVolume(float val) //��������� �����
    {
        volume = val;
    }

    public void ChangeResolution(int index) //��������� ����������
    {
        resolutionDropdown.ClearOptions(); //�������� ������ �������
        resolutions = Screen.resolutions; //��������� ��������� ����������
        List<string> options = new List<string>(); //�������� ������ �� ���������� ����������

        for (int i = 0; i < resolutions.Length; i++) //���������� ������ � ������ �����������
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //�������� ������ ��� ������
            options.Add(option); //���������� ������ � ������

            if (resolutions[i].Equals(Screen.currentResolution)) //���� ������� ���������� ����� ������������
            {
                currResolutionIndex = i; //�� ���������� ��� ������
            }
        }

        resolutionDropdown.AddOptions(options); //���������� ��������� � ���������� ������
        resolutionDropdown.value = currResolutionIndex; //��������� ������ � ������� �����������
        resolutionDropdown.RefreshShownValue(); //���������� ������������� ��������
    }

    public void ChangeFullscreenMode(bool val) //��������� ��� ���������� �������������� ������
    {
        isFullscreen = val;
    }

    public void SaveSettings()
    {
        //AudioMixer.SetFloat("MasterVolume", volume); //��������� ������ ���������
        Screen.fullScreen = isFullscreen; //��������� ��� ���������� �������������� ������
        Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //��������� ����������
    }
}