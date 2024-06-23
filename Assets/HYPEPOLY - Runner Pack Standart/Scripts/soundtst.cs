using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtst : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void test()
    {

        //VRSonicSoundManager.instance.PlaySound("Spike");
        VRSonicSoundManager.instance.PlaySound("Spike", transform.position);
    }
}
