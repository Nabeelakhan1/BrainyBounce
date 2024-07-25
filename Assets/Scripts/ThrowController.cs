using UnityEngine.EventSystems; // For detecting UI elements
using System.Collections.Generic; // For List<RaycastResult>
using UnityEngine;
using TMPro; // For TextMeshPro
public class ThrowController : MonoBehaviour
{
    [Header("Throw Settings")]
    public GameObject[] objectPrefabs; // Array to hold different colored ball prefabs
    public int totalThrows = 100;
    public float throwForce;

    [Header("UI Elements")]
    public TextMeshProUGUI ballCounterText; // For TextMeshPro

    [Header("Particle Settings")]
    public GameObject ballTrailParticleSystemPrefab; // Reference to the particle system prefab

    [Header("Game Settings")]
    public float gameSpeed = 1f;
    public bool isPaused = false; // Track if the game is paused

    private void Start()
    {
        // Initialize the ball counter text
        UpdateBallCounter();
    }

    private void Update()
    {
        // Check if the game is paused
        if (isPaused) return;

        // Check if there are throws remaining and if the throw button is pressed
        if (totalThrows > 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Check if the pointer is over a UI element
            if (!IsPointerOverUIElement())
            {
                // Decrement the total throws count
                totalThrows--;

                // Get the mouse position in screen coordinates
                Vector3 mousePosition = Input.mousePosition;
                // Convert the mouse position to world coordinates
                Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

                // Randomly select a prefab from the array
                GameObject selectedPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

                // Instantiate the selected object prefab from the camera position
                GameObject thrownObject = Instantiate(selectedPrefab, transform.position, Quaternion.identity);

                // Schedule the destruction of the thrown object after 3 seconds
                Destroy(thrownObject, 3f);

                // Attach the particle system to the thrown object
                if (ballTrailParticleSystemPrefab != null)
                {
                    GameObject particleSystemInstance = Instantiate(ballTrailParticleSystemPrefab, thrownObject.transform);
                    particleSystemInstance.transform.localPosition = Vector3.zero; // Adjust the position if needed
                }
                else
                {
                    Debug.LogWarning("Ball trail particle system prefab is not assigned.");
                }

                // Get the Rigidbody component of the thrown object
                Rigidbody rb = thrownObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    // Calculate the direction to throw the object (from camera to mouse position)
                    Vector3 throwDirection = (worldMousePosition - transform.position).normalized;

                    // Apply the force to throw the object
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
                }
                else
                {
                    Debug.LogError("Thrown object doesn't have a Rigidbody component!");
                }

                // Update the ball counter text
                UpdateBallCounter();
            }
        }
    }

    public void IncreaseBallCount(int amount)
    {
        if (!isPaused) // Ensure ball count cannot be increased when paused
        {
            totalThrows += amount;
            UpdateBallCounter();
        }
    }

    private void UpdateBallCounter()
    {
        ballCounterText.text = "" + totalThrows;
    }

    private void OnValidate()
    {
        // Ensure the game speed is updated in real-time in the Inspector
        Time.timeScale = gameSpeed;
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = gameSpeed;
    }

    private bool IsPointerOverUIElement()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
