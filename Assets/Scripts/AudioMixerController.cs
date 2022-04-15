using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioMixerController : MonoBehaviour
{
    public string VolumeType = "MasterVolume";
    public AudioMixer Mixer;
    public Slider Slider;
    public TextMeshProUGUI VolumeText;

    public float Multiplier = 30f;
    [Range(0,1)] public float DefaultSliderPercentage = 0.75f;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(VolumeType))
        {
            PlayerPrefs.SetFloat(VolumeType, DefaultSliderPercentage);
        }

        Slider.onValueChanged.AddListener(SliderValueChanged);

        Slider.value = PlayerPrefs.GetFloat(VolumeType);
    }

    public void SliderValueChanged(float sliderValue)
    {
        Mixer.SetFloat(VolumeType, SliderToDecibel(sliderValue));

        VolumeText.text = Mathf.Round(sliderValue * 100f) + "%";

        PlayerPrefs.SetFloat(VolumeType, sliderValue);
        PlayerPrefs.Save();
    }

    private float SliderToDecibel(float value)
    {
        return Mathf.Clamp(Mathf.Log10(value/DefaultSliderPercentage) * Multiplier, -80f, 20f);
    }
}
