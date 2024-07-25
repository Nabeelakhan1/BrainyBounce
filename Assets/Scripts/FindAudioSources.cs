using UnityEngine;

public class FindAudioSources : MonoBehaviour
{
    void Start()
    {
        // Find all objects with an AudioSource component
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            Debug.Log("GameObject: " + audioSource.gameObject.name);
        }
    }
}
