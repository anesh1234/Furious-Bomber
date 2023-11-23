using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject LevelSelectMenu;
    public GameObject Manual;
    public GameObject SettingsMenu;

    public void OnClickStart ()
    {
        LevelSelectMenu.SetActive (true);
    }

    public void OnClickManual ()
    {
        Manual.SetActive (true);
    }

    public void OnClickSettings()
    {
        SettingsMenu.SetActive (true);  
    }

    public void OnClickQuit ()
    {
        Application.Quit ();
    }
}
