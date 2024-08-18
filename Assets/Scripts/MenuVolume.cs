using UnityEngine;
using UnityEngine.UI;

public class MenuVolume : MonoBehaviour
{
    public AudioSource musicSource;  // Reference to the AudioSource
    public Slider volumeSlider;      // Reference to the Slider

    private void Start()
    {
        // Ensure the slider starts at the current volume level of the music
        if (musicSource != null && volumeSlider != null)
        {
            volumeSlider.value = musicSource.volume;
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }

    // This method is called whenever the slider's value changes
    private void OnVolumeChanged(float value)
    {
        if (musicSource != null)
        {
            musicSource.volume = value;  // Set the volume to the slider's value
        }
    }
}
