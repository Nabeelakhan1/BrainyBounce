using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    private Button button;
    private Image buttonImage;

    private void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>(); // Assuming there's an Image component for fading
        if (button == null)
        {
            Debug.Log($"Button component missing on {gameObject.name}");
        }
        if (buttonImage == null)
        {
            
        }

        UpdateButtonInteractable();
    }

    private void OnEnable()
    {
        UpdateButtonInteractable();
    }

    public void UpdateButtonInteractable()
    {
        // Ensure the button and buttonImage components are not null
        if (button == null || buttonImage == null)
        {

            Debug.Log("buttonImage components are null");
        }

        if (!LevelManager.Instance.IsLevelUnlocked(levelIndex))
        {
            button.interactable = false;
            buttonImage.color = new Color(1f, 1f, 1f, 0.7f);  // Fade the button (50% opacity)
        }
        else
        {
            button.interactable = true;
            buttonImage.color = new Color(1f, 1f, 1f, 1f);  // Normal appearance (100% opacity)
        }
    }
}
