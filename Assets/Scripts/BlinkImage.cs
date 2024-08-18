using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BlinkImage : MonoBehaviour
{
    public Image image;
    public float BlinkTime = 0.5f;
    private void Start()
    {
        if (image == null)
        {
            image=GetComponent<Image>(); 

        }
        StartCoroutine(BlinkAndDisppear());

    }
    private IEnumerator BlinkAndDisppear()
    {
        for(int i=0;i<4;i++)
        {
            image.enabled = true;
            yield return new WaitForSeconds(BlinkTime/2);

            image.enabled = false;
            yield return new WaitForSeconds(BlinkTime / 2);

            image.enabled = false;
        }
    }

}
