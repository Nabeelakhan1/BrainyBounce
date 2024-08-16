using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetLevel : MonoBehaviour
{
    // Reference to the Reset button
    public Button resetButton;

    void Start()
    {
        // Ensure the resetButton is connected in the Inspector
        if (resetButton != null)
        {
            // Add listener to call ResetLevel function when the button is clicked
            resetButton.onClick.AddListener(ResetCurrentLevel);
        }
        else
        {
            Debug.LogError("Reset button is not assigned!");
        }
    }

    // Function to reset the current level
    void ResetCurrentLevel()
    {
        // Get the active scene name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }
}
