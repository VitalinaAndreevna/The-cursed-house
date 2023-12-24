using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Работа с интерфейсами
using UnityEngine.SceneManagement; //Работа со сценами
using UnityEngine.Audio; //Работа с аудио


public class MenuManager : MonoBehaviour
{
    public bool isOpened = false; //Открыто ли меню
    public float volume = 50; //Громкость
    public bool isFullscreen = false; //Полноэкранный режим

    public Slider audioMixer; //Регулятор громкости

    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private int currResolutionIndex = 0; //Текущее разрешение

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
        SettingsMenu.enabled = isOpened; //Включение или отключение Canvas.
        MainMenu.enabled = !isOpened;
    }

    public void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
    }

    public void ChangeResolution(int index) //Изменение разрешения
    {
        resolutionDropdown.ClearOptions(); //Удаление старых пунктов
        resolutions = Screen.resolutions; //Получение доступных разрешений
        List<string> options = new List<string>(); //Создание списка со строковыми значениями

        for (int i = 0; i < resolutions.Length; i++) //Поочерёдная работа с каждым разрешением
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //Создание строки для списка
            options.Add(option); //Добавление строки в список

            if (resolutions[i].Equals(Screen.currentResolution)) //Если текущее разрешение равно проверяемому
            {
                currResolutionIndex = i; //То получается его индекс
            }
        }

        resolutionDropdown.AddOptions(options); //Добавление элементов в выпадающий список
        resolutionDropdown.value = currResolutionIndex; //Выделение пункта с текущим разрешением
        resolutionDropdown.RefreshShownValue(); //Обновление отображаемого значения
    }

    public void ChangeFullscreenMode(bool val) //Включение или отключение полноэкранного режима
    {
        isFullscreen = val;
    }

    public void SaveSettings()
    {
        //AudioMixer.SetFloat("MasterVolume", volume); //Изменение уровня громкости
        Screen.fullScreen = isFullscreen; //Включение или отключение полноэкранного режима
        Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //Изменения разрешения
    }
}