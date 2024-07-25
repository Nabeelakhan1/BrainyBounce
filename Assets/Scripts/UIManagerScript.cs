using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instance;

    public Button pauseButton;
    public Sprite pauseImage;
    public Sprite playImage;
    public GameObject pausePanel;
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
            pausePanel.SetActive(false);
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
        //audioSource.Play();
        Time.timeScale = isPaused ? 0 : 1;
        pauseButton.image.sprite = isPaused ? playImage : pauseImage;
        Debug.Log("Game is " + (isPaused ? "paused" : "unpaused") + ". Pause panel is " + (isPaused ? "shown" : "hidden") + ".");
        Debug.Log("Button image changed to " + (isPaused ? "playImage" : "pauseImage"));
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            TogglePause();
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
