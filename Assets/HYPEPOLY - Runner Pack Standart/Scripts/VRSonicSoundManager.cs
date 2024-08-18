using DarkTonic.MasterAudio;
using UnityEngine;


public class VRSonicSoundManager : MonoBehaviour
{

    public static VRSonicSoundManager instance;

    public string soundName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {    // play sound on start
        PlaySound(soundName);
    }

    [ContextMenu("PlaySoundFromInspector")]
    public void PlaySoundFromInspector()
    {
        PlaySound(soundName);
    }
    
    public void PlaySound(string soundName)
    {
        // play sound
        MasterAudio.PlaySound(soundName);
    
    }

    public void PlaySound(string soundName, Vector3 position)
    {
        // play sound
        MasterAudio.PlaySound3DAtVector3(soundName,position,0.5f);

    }



}