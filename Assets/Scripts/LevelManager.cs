using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    private bool[] levelUnlocked;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeLevelProgress();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeLevelProgress()
    {
        levelUnlocked = new bool[SceneManager.sceneCountInBuildSettings];
        LoadLevelProgress();

        if (!levelUnlocked[1])
        {
            levelUnlocked[1] = true;  // Ensure level 1 is always unlocked
            SaveLevelProgress();
        }
    }

    public void UnlockLevel(int levelIndex)
    {
        if (levelIndex < levelUnlocked.Length)
        {
            levelUnlocked[levelIndex] = true;
            SaveLevelProgress();
            Debug.Log($"Level {levelIndex} unlocked.");
        }
    }

    public bool IsLevelUnlocked(int levelIndex)
    {
        if (levelIndex < levelUnlocked.Length)
        {
            return levelUnlocked[levelIndex];
        }
        else
        {
            return false;
        }
    }

    private void SaveLevelProgress()
    {
        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            PlayerPrefs.SetInt($"Level_{i}_Unlocked", levelUnlocked[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    private void LoadLevelProgress()
    {
        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            levelUnlocked[i] = PlayerPrefs.GetInt($"Level_{i}_Unlocked", 0) == 1;
        }
    }

    // Reset function with UI update trigger
    public void ResetAllLevels()
    {
        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            levelUnlocked[i] = (i == 1);  // Only unlock level 1
            PlayerPrefs.SetInt($"Level_{i}_Unlocked", (i == 1) ? 1 : 0);  // Save progress
        }
        PlayerPrefs.Save();  // Save PlayerPrefs to persist changes
        Debug.Log("All levels reset, except level 1.");

        // Trigger UI update for all level buttons
        UpdateAllLevelButtons();
    }

    // Function to update all level buttons
    private void UpdateAllLevelButtons()
    {
        LevelButton[] levelButtons = FindObjectsOfType<LevelButton>();
        foreach (LevelButton button in levelButtons)
        {
            button.UpdateButtonInteractable();  // Update the button state and visual
        }
    }
}
