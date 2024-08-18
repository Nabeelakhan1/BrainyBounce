using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject Tutorialpanel;
    public Button OkButton;
    public Button ButtonToDisable; // Reference to the button to disable

    void Start()
    {
        Tutorialpanel.SetActive(false);
        OkButton.onClick.AddListener(ResumeGame);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            Tutorialpanel.SetActive(true);
            ButtonToDisable.interactable = false; // Disable the button
        }
    }

    public void ResumeGame()
    {
        Tutorialpanel.SetActive(false);
        Time.timeScale = 1f;
        ButtonToDisable.interactable = true; // Enable the button
    }

    // Update is called once per frame
    void Update()
    {
    }
}
