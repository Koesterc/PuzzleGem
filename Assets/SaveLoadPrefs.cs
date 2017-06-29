using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadPrefs : MonoBehaviour {

    //loading prefs
    public static void Load()
    {
        if (PlayerPrefs.HasKey("BGMvolume"))
            PauseMenus.BGMvolume = PlayerPrefs.GetFloat("BGMvolume");
        if (PlayerPrefs.HasKey("SFXvolume"))
            PauseMenus.SFXvolume = PlayerPrefs.GetFloat("SFXvolume");
        if (PlayerPrefs.HasKey("brightness"))
            PauseMenus.brightness = PlayerPrefs.GetFloat("brightness");
        if (PlayerPrefs.HasKey("scaleTime"))
            PauseMenus.scaleTime = PlayerPrefs.GetFloat("scaleTime");

        if (PlayerPrefs.HasKey("difficulty"))
            PauseMenus.difficulty = (PauseMenus.Difficulty)PlayerPrefs.GetInt("difficulty");
        if (PlayerPrefs.HasKey("gameSpeed"))
            PauseMenus.gameSpeed = (PauseMenus.GameSpeed)PlayerPrefs.GetInt("gameSpeed");
        if (PlayerPrefs.HasKey("quality"))
            PauseMenus.quality = (PauseMenus.Quality)PlayerPrefs.GetInt("Quality");
        if (PlayerPrefs.HasKey("resolution"))
            PauseMenus.resolution = (PauseMenus.Resolution)PlayerPrefs.GetInt("resolution");
        if (PlayerPrefs.HasKey("audioSettings"))
            PauseMenus.audioSettings = (PauseMenus.AudioSettings)PlayerPrefs.GetInt("AudioSettings");


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
        PlayerPrefs.SetFloat("BGMvolume", PauseMenus.BGMvolume);
        PlayerPrefs.SetFloat("SFXvolume", PauseMenus.SFXvolume);
        PlayerPrefs.SetFloat("brightness", PauseMenus.brightness);
        PlayerPrefs.SetFloat("scaleTime", PauseMenus.scaleTime);

        PlayerPrefs.SetInt("difficulty", (int)PauseMenus.difficulty);
        PlayerPrefs.SetInt("gameSpeed", (int)PauseMenus.gameSpeed);
        PlayerPrefs.SetInt("resolution", (int)PauseMenus.resolution);
        PlayerPrefs.SetInt("quality", (int)PauseMenus.quality);
        PlayerPrefs.SetInt("audioSettings", (int)PauseMenus.audioSettings);

        //PlayerPrefs.Save();
    }
}
