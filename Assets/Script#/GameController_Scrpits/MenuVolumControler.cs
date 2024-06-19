using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuVolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    // Determina el valor del slider de volumen en base al valor guardado 
    void Start()
    {
        
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        audioSource.volume = volumeSlider.value;

        
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Establece el volumen del audio source y guarda el valor 
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
