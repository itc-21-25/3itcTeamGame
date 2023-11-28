using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        // Initialize sliders and set default volume values
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        // Add listener methods to respond to slider changes
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    public void ChangeMusicVolume(float volume)
    {
        // Update music volume and save it to PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", volume);
        // Apply changes to the audio system (you'll need to implement your audio system here)
        // Example: AudioManager.SetMusicVolume(volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        // Update SFX volume and save it to PlayerPrefs
        PlayerPrefs.SetFloat("SFXVolume", volume);
        // Apply changes to the audio system (you'll need to implement your audio system here)
        // Example: AudioManager.SetSFXVolume(volume);
    }
}
