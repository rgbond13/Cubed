using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveInfo : MonoBehaviour
{
    Text usertext;

    private void SetUsername()
    {
        usertext = gameObject.GetComponent<Text>();

        string username = usertext.text.ToString();
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.Save();
    }
}
