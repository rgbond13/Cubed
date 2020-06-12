using System.Collections;
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
        Debug.Log("Started");
        CloseMenu(mainMenu);
        OpenMenu(loadMenu);
        Debug.Log("Arrived here");
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
}
