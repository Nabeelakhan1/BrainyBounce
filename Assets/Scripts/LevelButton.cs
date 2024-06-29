using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        UpdateButtonInteractable();
    }

    private void OnEnable()
    {
        UpdateButtonInteractable();
    }

    private void UpdateButtonInteractable()
    {
        if (!LevelManager.Instance.IsLevelUnlocked(levelIndex))
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
