using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Toggle fsToggle;
    public Dropdown resDD;
    public Dropdown tqDD;
    public Dropdown aaDD;
    public Dropdown vsDD;
    public Slider avSlider;

    public AudioSource audioS;
    public Resolution[] res;


    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fsToggle.onValueChanged.AddListener(delegate { OnFullscreentoggle(); });
        resDD.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        tqDD.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        aaDD.onValueChanged.AddListener(delegate { OnAntiAliasChange(); });
        vsDD.onValueChanged.AddListener(delegate { OnVsyncChange(); });
        avSlider.onValueChanged.AddListener(delegate { OnAudioChange(); });

        res = Screen.resolutions;
        foreach (Resolution resolution in res)
        {
            resDD.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }

    public void OnFullscreentoggle()
    {

        gameSettings.fullscreen= Screen.fullScreen = fsToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(res[resDD.value].width, res[resDD.value].height, Screen.fullScreen);
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = tqDD.value;
        
    }

    public void OnAntiAliasChange()
    {
        QualitySettings.antiAliasing = gameSettings.antialias = (int)Mathf.Pow(2, aaDD.value);
    }

    public void OnVsyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vsync = vsDD.value;
    }

    public void OnAudioChange()
    {
        audioS.volume = gameSettings.audioVolume = avSlider.value;

    }

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {

    }





}
