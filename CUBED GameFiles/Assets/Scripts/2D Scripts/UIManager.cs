﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] loadMenu;

    [SerializeField]
    GameObject[] settings;

    [SerializeField]
    GameObject[] mainMenu;

    void Start()
    {

    }

    void StartClicked()
    {
        CloseMenu(mainMenu);
        OpenMenu(loadMenu);
    }

    void SettingsClicked()
    {
        CloseMenu(mainMenu);
        OpenMenu(settings);
    }

    void CloseClicked()
    {
        CloseMenu(settings);
        CloseMenu(loadMenu);
        OpenMenu(mainMenu);
    }

    private void CloseMenu(GameObject[] menu)
    {
        foreach (GameObject widget in menu)
        {
            widget.SetActive(false);
        }
    }

    private void OpenMenu(GameObject[] menu)
    {
        foreach (GameObject widget in menu)
        {
            widget.SetActive(true);
        }
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    void LoadWorld()
    {
        ChangeScene.LoadGame();
    }

    void GenerateWorld()
    {
        LoadWorld();
    }
}
