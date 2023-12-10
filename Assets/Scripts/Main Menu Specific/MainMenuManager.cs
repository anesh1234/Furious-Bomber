using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject LevelSelectMenu;
    public GameObject Manual;
    public GameObject SettingsMenu;
    public GameObject banner;


    public void OnClickStart ()
    {
        LevelSelectMenu.SetActive (true);
        banner.SetActive (false);
    }

    public void OnClickManual ()
    {
        Manual.SetActive (true);
    }

    public void OnClickSettings()
    {
        SettingsMenu.SetActive (true);
        banner.SetActive(false);
    }

    public void OnClickQuit ()
    {
        Application.Quit ();
    }
}
