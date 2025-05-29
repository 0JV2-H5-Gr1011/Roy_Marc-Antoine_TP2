using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControleVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        volumeSlider.value = volume;
        SetVolume(volume);

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20;
        mixer.SetFloat("Volume", dB);

        PlayerPrefs.SetFloat("MusicVolume", value);
    }
}