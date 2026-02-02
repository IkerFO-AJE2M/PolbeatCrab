using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        slider.value = savedVolume;
        AudioListener.volume = savedVolume;

        slider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
}
