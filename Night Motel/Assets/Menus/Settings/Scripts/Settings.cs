using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.IO;  // include the System.IO namespace

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;
  
    public void SetVolume(float volume)
    {
        string writeText = volumeSlider.value.ToString();  // Create a text string

        File.WriteAllText("volume.inf", writeText);  // Create a file and write the content of writeText to it

        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public TMP_Dropdown resolutionDropdown; // or TMP_Dropdown if using TextMeshPro

    private Resolution[] availableResolutions;

    void Start()
    {
        string slidervalue= File.ReadAllText("volume.inf");
        float sildervalueFloat = float.Parse(slidervalue);
        volumeSlider.value = sildervalueFloat;



        // Get all available resolutions
        availableResolutions = Screen.resolutions;

        // Clear any existing options
        resolutionDropdown.ClearOptions();

        // Create list of resolution options as strings
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < availableResolutions.Length; i++)
        {
            string option = availableResolutions[i].width + " x " + availableResolutions[i].height;
            options.Add(option);

            // Check if current screen resolution matches the available one
            if (availableResolutions[i].width == Screen.width &&
                availableResolutions[i].height == Screen.height &&
                availableResolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        // Add options to the dropdown
        resolutionDropdown.AddOptions(options);

        // Set current resolution as default selected
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Add listener to handle changes from dropdown
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution chosenResolution = availableResolutions[resolutionIndex];
        Screen.SetResolution(chosenResolution.width, chosenResolution.height, Screen.fullScreenMode, chosenResolution.refreshRate);
    }
}
