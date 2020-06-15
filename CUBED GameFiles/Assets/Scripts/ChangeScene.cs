using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
