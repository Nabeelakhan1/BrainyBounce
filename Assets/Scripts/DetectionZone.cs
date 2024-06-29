using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectionZone : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public GameObject[] otherUIElements; // Array of other UI elements to disable

    public GameObject[] hearts; // Array to hold references to the heart UI elements
    public GameObject bloodEffect; // Reference to the blood effect UI element

    private int health = 6; // Player's health

    private void OnEnable()
    {
        // Reset health
        health = 6;

        // Re-enable all heart UI elements
        foreach (var heart in hearts)
        {
            heart.SetActive(true);
        }

        // Ensure the blood effect is hidden
        if (bloodEffect != null)
        {
            bloodEffect.SetActive(false);
        }

        // Hide the game over panel
        gameOverPanel.SetActive(false);

        // Enable other UI elements
        foreach (var uiElement in otherUIElements)
        {
            uiElement.SetActive(true);
        }

        // Reset time scale
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Decrease health by 1
            health--;

            // Disable a heart UI element based on the current health
            if (health >= 0 && health < hearts.Length)
            {
                hearts[health].SetActive(false);
            }

            // Check if health is greater than 0 to show the blood effect
            if (health > 0)
            {
                ShowBloodEffect(); // Show blood effect
            }
            else
            {
                GameOver(); // End the game if health is 0
            }
        }
    }

    private void ShowBloodEffect()
    {
        if (bloodEffect != null)
        {
            bloodEffect.SetActive(true);
            // Optionally, disable the blood effect after some time
            Invoke("HideBloodEffect", 1f); // Adjust the time as needed
        }
    }

    private void HideBloodEffect()
    {
        if (bloodEffect != null)
        {
            bloodEffect.SetActive(false);
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f; // Stop the game

        // Disable all other UI elements except the game over panel
        foreach (var uiElement in otherUIElements)
        {
            uiElement.SetActive(false);
        }

        // Hide blood effect manually
        if (bloodEffect != null)
        {
            bloodEffect.SetActive(false);
        }

        // Display the Game Over panel
        gameOverPanel.SetActive(true);

        // Optionally, perform other actions or display messages
        // Debug.Log("Game Over! An object tagged as 'Obstacle' collided with the player.");
    }

    public void RestartGame()
    {
        health = 6; // Reset health

        // Re-enable all heart UI elements
        foreach (var heart in hearts)
        {
            heart.SetActive(true);
        }

        Time.timeScale = 1f; // Reset the time scale

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
