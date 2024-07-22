using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instance;

    public Button pauseButton; // Reference to the pause button
    public Sprite pauseImage;  // Reference to the pause image
    public Sprite playImage;   // Reference to the play image
    public GameObject pausePanel;  // Reference to the pause panel
    private bool isPaused = false;
    private AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);  // Ensure the pause panel is hidden at start
        }
        else
        {
            Debug.LogError("Pause panel is not assigned in the inspector.");
        }

        if (pauseButton == null)
        {
            Debug.LogError("Pause button is not assigned in the inspector.");
        }

        if (pauseImage == null || playImage == null)
        {
            Debug.LogError("Pause or play image is not assigned in the inspector.");
        }
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for pause/unpause input (optional, if you want to toggle with a key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (pausePanel == null || pauseButton == null || pauseImage == null || playImage == null)
        {
            Debug.LogError("Required UI components are not assigned in the inspector.");
            return;
        }

        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        audioSource.Play();
        Time.timeScale = isPaused ? 0 : 1;  // Pause or unpause the game
        pauseButton.image.sprite = isPaused ? playImage : pauseImage; // Switch button image
        Debug.Log("Game is " + (isPaused ? "paused" : "unpaused") + ". Pause panel is " + (isPaused ? "shown" : "hidden") + ".");
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            TogglePause();  // Resumes the game by toggling the pause state
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OpenSettings()
    {
        // Implement settings functionality here
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void RestartLevel()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartButton()
    {
        RestartLevel();
    }

    public void HomeButton()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
