using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(480, 854, false);
    }

    public void StartButton(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
