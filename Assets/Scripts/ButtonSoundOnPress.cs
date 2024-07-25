using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundOnPress : MonoBehaviour, IPointerDownHandler
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component is missing from the GameObject.");
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
