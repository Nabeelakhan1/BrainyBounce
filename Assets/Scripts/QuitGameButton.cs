using UnityEngine;
using UnityEngine.UI; // For Button component

public class QuitGameButton : MonoBehaviour
{
    private void Start()
    {
        // Get the Button component attached to this GameObject
        Button button = GetComponent<Button>();

        // Add a listener to the button to call the QuitGame method when clicked
        if (button != null)
        {
            button.onClick.AddListener(QuitGame);
        }
        
    }

    private void QuitGame()
    {
        // Quit the application
        Application.Quit();

    }

}
