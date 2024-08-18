using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VRSonicSoundManager.instance.PlaySound("Blade", transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
