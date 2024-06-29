using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private bool[] levelUnlocked; // Array to track unlocked levels

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize levelUnlocked array
            levelUnlocked = new bool[SceneManager.sceneCountInBuildSettings];
            LoadLevelProgress();

            // Ensure the first playable level (index 1) is unlocked
            if (!levelUnlocked[1])
            {
                levelUnlocked[1] = true;
                SaveLevelProgress();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockLevel(int levelIndex)
    {
        if (levelIndex < levelUnlocked.Length)
        {
            levelUnlocked[levelIndex] = true;
            SaveLevelProgress();
        }
        else
        {
            Debug.LogError($"Trying to unlock level {levelIndex} which is out of range.");
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
            Debug.LogError($"Trying to check if level {levelIndex} is unlocked which is out of range.");
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
}
