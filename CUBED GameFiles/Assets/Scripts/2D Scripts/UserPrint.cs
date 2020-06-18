using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserPrint : MonoBehaviour
{
    TextMeshProUGUI user;
    string username;

    void Start()
    {
        user = gameObject.GetComponent<TextMeshProUGUI>();
        username = PlayerPrefs.GetString("username");
        user.SetText(username);
    }
}
