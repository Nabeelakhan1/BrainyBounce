using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeSound : MonoBehaviour
{
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hang()
    {

        VRSonicSoundManager.instance.PlaySound("Blade", transform.position);

    }
}




