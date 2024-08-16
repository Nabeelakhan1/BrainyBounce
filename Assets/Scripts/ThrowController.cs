using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private bool canThrow = true;

    private void Start()
    {
        UpdateBallCounter();
    }

    private void Update()
    {
        // Prevent spawning if the game is paused
        if (UIManagerScript.instance != null && UIManagerScript.instance.IsGamePaused()) return;

        // Check if there are throws remaining and the screen is tapped
        if (totalThrows > 0 && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if the touch is over a UI element
            if (!IsPointerOverUIElement())
            {
                SpawnBall();
            }
        }
    }

    private void SpawnBall()
    {
        totalThrows--;

        Vector3 touchPosition = Input.GetTouch(0).position;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 10f));

        GameObject selectedPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
        GameObject thrownObject = Instantiate(selectedPrefab, transform.position, Quaternion.identity);

        Destroy(thrownObject, 3f);

        if (ballTrailParticleSystemPrefab != null)
        {
            GameObject particleSystemInstance = Instantiate(ballTrailParticleSystemPrefab, thrownObject.transform);
            particleSystemInstance.transform.localPosition = Vector3.zero;
        }

        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 throwDirection = (worldPosition - transform.position).normalized;
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }

        UpdateBallCounter();
    }

    private void UpdateBallCounter()
    {
        ballCounterText.text = "" + totalThrows;
    }

    private bool IsPointerOverUIElement()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
