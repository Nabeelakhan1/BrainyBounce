using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Initialize the slider value with the current volume from MusicManager
        volumeSlider.value = MusicManager.Instance.GetVolume();

        // Add listener to the slider to update volume instantly
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        // Ensure the audio source is not paused when the game is paused
        MusicManager.Instance.musicSource.ignoreListenerPause = true;
    }

    private void OnEnable()
    {
        // Ensure volume is set correctly when this panel is enabled
        volumeSlider.value = MusicManager.Instance.GetVolume();
    }

    private void OnVolumeChanged(float volume)
    {
        // Set the volume in MusicManager
        MusicManager.Instance.SetVolume(volume);

        // Manually update the AudioSource volume to apply changes instantly
        MusicManager.Instance.musicSource.volume = volume;

        // Ensure that the AudioListener is not paused to allow changes
        AudioListener.pause = false;
    }
}
