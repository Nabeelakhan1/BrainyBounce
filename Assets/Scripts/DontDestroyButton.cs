using UnityEngine;
using UnityEngine.UI;

public class DontDestroyButton : MonoBehaviour
{
    private void Awake()
    {
        // Keep this button across scene loads
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        // Get the Button component attached to this GameObject
        Button resetButton = GetComponent<Button>();

        // Ensure the Button component exists
        if (resetButton != null)
        {
            // Clear any previous listeners to avoid duplicate calls
            resetButton.onClick.RemoveAllListeners();

            // Add a new listener to call the ResetAllLevels method from the LevelManager
            resetButton.onClick.AddListener(() =>
            {
                if (LevelManager.Instance != null)
                {
                    LevelManager.Instance.ResetAllLevels();
                }
                else
                {
                    Debug.Log("LevelManager instance is missing!");
                }
            });
        }
        else
        {
            Debug.Log("Button component is missing on this GameObject!");
        }
    }
}
