using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{
    public GameObject levelCompletePanel;

    // Called when the level is completed
    public void OnLevelComplete(int completedLevelIndex)
    {
        if (LevelManager.Instance == null)
        {
            Debug.LogError("LevelManager instance is not set.");
            return;
        }

        // Unlock the next level
        int nextLevelIndex = completedLevelIndex + 1;
        LevelManager.Instance.UnlockLevel(nextLevelIndex);

        // Show level complete panel and pause the game
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    // Called when Restart Level button is clicked
    public void RestartLevel()
    {
        Time.timeScale = 1; // Resume the game
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }

    // Called when Next Level button is clicked
    public void LoadNextLevel()
    {
        Time.timeScale = 1; // Resume the game
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        // Check if the next level is unlocked before loading
        if (LevelManager.Instance.IsLevelUnlocked(nextLevelIndex))
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.LogError($"Next level {nextLevelIndex} is not unlocked.");
        }
    }
}
