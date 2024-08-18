using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCounter : MonoBehaviour
{
    private void Start()
    {
        GameObject[] rings = GameObject.FindGameObjectsWithTag("ring");
        int ringCount=rings.Length;
        Debug.Log("number or coins in the level" + ringCount);



    }
}
