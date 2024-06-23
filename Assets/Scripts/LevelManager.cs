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

            // Initialize levelUnlocked array (for example, all levels locked initially)
            levelUnlocked = new bool[SceneManager.sceneCountInBuildSettings];
            levelUnlocked[1] = true; // Unlock the first level (assuming index 0 is main menu or starting level)
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
}
