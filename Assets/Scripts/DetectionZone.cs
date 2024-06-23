using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectionZone : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public GameObject[] otherUIElements; // Array of other UI elements to disable

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Time.timeScale = 0f; // Stop the game

            // Disable all other UI elements except the game over panel
            foreach (var uiElement in otherUIElements)
            {
                uiElement.SetActive(false);
            }

            // Display the Game Over panel
            gameOverPanel.SetActive(true);

            // Optionally, perform other actions or display messages
            // Debug.Log("Game Over! An object tagged as 'Obstacle' collided with the player.");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset the time scale

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
