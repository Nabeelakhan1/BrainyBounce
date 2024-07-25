using System.Collections;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundRepeatedly());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void test()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource component is missing.");
        }
    }

    private IEnumerator PlaySoundRepeatedly()
    {
        while (true)
        {
            test(); // Play the sound
            yield return new WaitForSeconds(3f); // Wait for 3 seconds
        }
    }
}
