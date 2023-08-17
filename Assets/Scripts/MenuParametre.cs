using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class MenuParametre : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropDown;

    Resolution[] resolutions;


    public void Start()
    { 

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width= resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();
        int resolutionAcutelleIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                resolutionAcutelleIndex = i;
            }

        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value= resolutionAcutelleIndex;
        resolutionDropDown.RefreshShownValue();
        
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);

        audioMixer.SetFloat("volume", volume);

    }

    public void SetPleinEcran(bool ecran)
    {
        Screen.fullScreen = ecran;

    }

    public void SetResolution(int indexResolution)
    {

        Resolution resolution = resolutions[indexResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
}
