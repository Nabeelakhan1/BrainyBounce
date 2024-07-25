using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject Tutorialpanel;
    public Button OkButton;
    
    void Start()
    {
        Tutorialpanel.SetActive(false);
        OkButton.onClick.AddListener(ResumeGame);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           
            Time.timeScale = 0f;
            Tutorialpanel.SetActive(true);
         

        }
    }
     public void ResumeGame()
    {
        Tutorialpanel.SetActive(false);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
