using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    public AudioSource musicSource;  // Reference to the AudioSource for the background music

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Ensure this object persists across scenes
        }
        else
        {
            Destroy(gameObject);  // Prevent duplicate instances
        }
    }

    public void SetVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }

    public float GetVolume()
    {
        return musicSource != null ? musicSource.volume : 0;
    }
}
