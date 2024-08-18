using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelCompletion : MonoBehaviour
{
    public GameObject levelCompletePanel;
    public GameObject gameLosePanel;

    // Text fields for level complete panel
    public TMP_Text coinsCollectedTextComplete;
    public TMP_Text timeTakenTextComplete;
    public TMP_Text accuracyTextComplete;

    // Text fields for game lose panel
    public TMP_Text coinsCollectedTextLose;
    public TMP_Text timeTakenTextLose;
    public TMP_Text accuracyTextLose;

    private int totalCoins;
    private int startTime;
    private int successfulThrows;
    private int totalThrows;

    private void Start()
    {
        ResetStats();
        startTime = (int)Time.time; 
        Debug.Log("Level started. Stats reset.");
    }

    // Called when the level is completed
    public void OnLevelComplete(int completedLevelIndex, bool isWin)
    {
        Debug.Log("Level completion called.");

        if (LevelManager.Instance == null)
        {
            Debug.LogError("LevelManager instance is not set.");
            return;
        }

        // Calculate the stats
        totalCoins = FindObjectOfType<CoinCounter>().GetCoinCount();
        int timeTaken = (int)(Time.time - startTime); // Time taken as integer
        int accuracy = totalThrows == 0 ? 0 : (int)((float)successfulThrows / totalThrows * 100); // Accuracy as integer

        // Update the stats text for the appropriate panel
        if (isWin)
        {
            coinsCollectedTextComplete.text = $"{totalCoins}";
            timeTakenTextComplete.text = $"{timeTaken}s";
            accuracyTextComplete.text = $"{accuracy}%";

            levelCompletePanel.SetActive(true);
        }
        else
        {
            coinsCollectedTextLose.text = $"{totalCoins}";
            timeTakenTextLose.text = $"{timeTaken}s";
            accuracyTextLose.text = $"{accuracy}%";

            gameLosePanel.SetActive(true);
        }

        Time.timeScale = 0; // Pause the game

        // Unlock the next level if won
        if (isWin)
        {
            int nextLevelIndex = completedLevelIndex + 1;
            LevelManager.Instance.UnlockLevel(nextLevelIndex);
            Debug.Log($"Next level {nextLevelIndex} unlocked.");
        }
    }

    // Called when Restart Level button is clicked
    public void RestartLevel()
    {
        Time.timeScale = 1; // Resume the game
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
        Debug.Log($"Restarting level {currentLevelIndex}.");
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
            Debug.Log($"Loading next level {nextLevelIndex}.");
        }
        else
        {
            Debug.LogError($"Next level {nextLevelIndex} is not unlocked.");
        }
    }

    // Method to reset stats
    private void ResetStats()
    {
        totalCoins = 0;
        startTime = (int)Time.time; // Start time as integer
        successfulThrows = 0;
        totalThrows = 0;
        Debug.Log("Stats reset.");
    }

    // Methods to track throws
    public void TrackThrow(bool isSuccessful)
    {
        totalThrows++;
        if (isSuccessful)
        {
            successfulThrows++;
        }
        Debug.Log($"Throw tracked. Successful: {successfulThrows}, Total: {totalThrows}");
    }

    private void OnEnable()
    {
        ResetStats();
        Debug.Log("Level enabled, stats reset.");
    }

    private void OnDisable()
    {
        Debug.Log("Level disabled, calculating final stats.");
        CalculateAndDisplayStats();
    }

    private void CalculateAndDisplayStats()
    {
        totalCoins = FindObjectOfType<CoinCounter>().GetCoinCount();
        int timeTaken = (int)(Time.time - startTime); // Time taken as integer
        int accuracy = totalThrows == 0 ? 0 : (int)((float)successfulThrows / totalThrows * 100); // Accuracy as integer

        coinsCollectedTextComplete.text = $"{totalCoins}";
        timeTakenTextComplete.text = $"{timeTaken}s";
        accuracyTextComplete.text = $"{accuracy}%";

        coinsCollectedTextLose.text = $"{totalCoins}";
        timeTakenTextLose.text = $"{timeTaken}s";
        accuracyTextLose.text = $"{accuracy}%";

        Debug.Log($"Final Stats - Total Coins: {totalCoins}, Time Taken: {timeTaken}s, Accuracy: {accuracy}%");
    }
}
