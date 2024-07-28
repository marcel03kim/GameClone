using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerControl : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MusicMasterSlider;

    private void Awake()
    {
        MusicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
    }


    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    
}
