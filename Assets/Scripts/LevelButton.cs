// LevelButton.cs script
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (!LevelManager.Instance.IsLevelUnlocked(levelIndex))
        {
            button.interactable = false;
        }
    }
}
