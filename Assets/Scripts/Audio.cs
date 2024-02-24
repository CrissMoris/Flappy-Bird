using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider MainSong;

    void SetSlider()
    {
        MainSong.value = PlayerPrefs.GetFloat("MainSong", 0.75f); // Default value 0.75f if not found
    }

    private void Start()
    {
        // Load volume value from PlayerPrefs and set it to the audio mixer
        float volumeValue = PlayerPrefs.GetFloat("MainSong", 0.75f);
        mixer.SetFloat("MainSong", Mathf.Log10(volumeValue) * 20);

        // Set slider value to reflect the volume
        SetSlider();

        // Update volume initially
        UpdateSongVolume();
    }

    public void UpdateSongVolume()
    {
        // Adjust volume logarithmically
        float volume = MainSong.value;
        float volumeLevel = volume == 0 ? -80f : Mathf.Log10(volume) * 20; // Set volume to -80 dB when slider is at minimum position
        mixer.SetFloat("MainSong", volumeLevel);
        PlayerPrefs.SetFloat("MainSong", volume);
    }

    // Called when the settings are closed
    public void OnSettingsClosed()
    {
        UpdateSongVolume();
    }
}
