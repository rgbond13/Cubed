using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveInfo : MonoBehaviour
{
    public TextMeshProUGUI usertext;

    private void SetUsername()
    {
        usertext = gameObject.GetComponent<TextMeshProUGUI>();

        string username = usertext.text;
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.Save();
    }
}
