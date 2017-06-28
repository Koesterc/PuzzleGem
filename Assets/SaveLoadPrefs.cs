using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadPrefs : MonoBehaviour {

    //loading prefs
    public static void Load()
    {
        PauseMenus.BGMvolume = PlayerPrefs.GetFloat("BGMVolume");
        PauseMenus.SFXvolume = PlayerPrefs.GetFloat("SFXVolume");
        PauseMenus.brightness = PlayerPrefs.GetFloat("Brightness");
        PauseMenus.scaleTime = PlayerPrefs.GetFloat("scaleTime");

        PauseMenus.difficulty = (PauseMenus.Difficulty)PlayerPrefs.GetInt("Diff");
        PauseMenus.gameSpeed = (PauseMenus.GameSpeed)PlayerPrefs.GetInt("GameSpeed");
        PauseMenus.quality = (PauseMenus.Quality)PlayerPrefs.GetInt("Quality");
        PauseMenus.resolution = (PauseMenus.Resolution)PlayerPrefs.GetInt("Resolution");

     
        switch (PauseMenus.quality)
        {
            default:
                QualitySettings.SetQualityLevel(0);
                break;
            case PauseMenus.Quality.Good:
                QualitySettings.SetQualityLevel(1);
                break;
            case PauseMenus.Quality.High:
                QualitySettings.SetQualityLevel(2);
                break;
        }

        switch (PauseMenus.resolution)
        {
            default:
                Screen.SetResolution(600, 400, false);
                PauseMenus.resolution = PauseMenus.Resolution.Small;
                break;
            case PauseMenus.Resolution.Small:
                Screen.SetResolution(800, 600, false);
                PauseMenus.resolution = PauseMenus.Resolution.Medium;
                break;
            case PauseMenus.Resolution.Medium:
                Screen.SetResolution(Screen.width, Screen.height, true);
                PauseMenus.resolution = PauseMenus.Resolution.Fullscreen;
                break;
        }
    }

    //saving all data
    public static void Save()
    {
        PlayerPrefs.SetFloat("BGMVolume", PauseMenus.BGMvolume);
        PlayerPrefs.SetFloat("SFXVolume", PauseMenus.SFXvolume);
        PlayerPrefs.SetFloat("Brightness", PauseMenus.brightness);
        PlayerPrefs.SetFloat("scaleTime", PauseMenus.scaleTime);

        PlayerPrefs.SetInt("Diff", (int)PauseMenus.difficulty);
        PlayerPrefs.SetInt("GameSpeed", (int)PauseMenus.gameSpeed);
        PlayerPrefs.SetInt("Resolution", (int)PauseMenus.resolution);
        PlayerPrefs.SetInt("Quality", (int)PauseMenus.quality);

        //PlayerPrefs.Save();
    }
}
