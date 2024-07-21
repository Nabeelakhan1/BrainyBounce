using UnityEngine;

public class ThrownObject : MonoBehaviour
{
    private CoinCounter coinCounter; // Reference to the CoinCounter script
    private LevelCompletion levelCompletion; // Reference to the LevelCompletion script

    void Start()
    {
        // Find the CoinCounter in the scene
        coinCounter = FindObjectOfType<CoinCounter>();

        if (coinCounter == null)
        {
            Debug.LogError("CoinCounter not found in the scene. Please ensure there is a GameObject with a CoinCounter script.");
        }

        // Find the LevelCompletion in the scene
        levelCompletion = FindObjectOfType<LevelCompletion>();

        if (levelCompletion == null)
        {
            Debug.LogError("LevelCompletion not found in the scene. Please ensure there is a GameObject with a LevelCompletion script.");
        }

        // Log the tag of this game object (the thrown object)
        Debug.Log("Thrown object tag: " + gameObject.tag);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Log collision information
        Debug.Log("Collision detected with: " + collision.gameObject.name + ", Tag: " + collision.gameObject.tag);

        bool isSuccessfulThrow = collision.gameObject.CompareTag("ring");

        // Track the throw
        if (levelCompletion != null)
        {
            levelCompletion.TrackThrow(isSuccessfulThrow);
        }

        // Check if the collided object has the tag "ring"
        if (isSuccessfulThrow)
        {
            // Log before destroying the object
            Debug.Log("Collided with object tagged as ring: " + collision.gameObject.name);

            // Increase the coin count
            if (coinCounter != null)
            {
                coinCounter.AddCoin();
                Debug.Log("Coin added successfully.");
            }
            else
            {
                Debug.LogWarning("CoinCounter reference is missing.");
            }

            // Destroy the object tagged as "ring"
            Debug.Log("Destroying object tagged as ring: " + collision.gameObject.name);
            Destroy(collision.gameObject);

          
        }
        else
        {
            Debug.Log("Collided object is not tagged as ring, it is tagged as: " + collision.gameObject.tag);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Log trigger information
        Debug.Log("Trigger detected with: " + other.gameObject.name + ", Tag: " + other.gameObject.tag);

        bool isSuccessfulThrow = other.CompareTag("ring");

        // Track the throw
        if (levelCompletion != null)
        {
            levelCompletion.TrackThrow(isSuccessfulThrow);
        }

        // Check if the triggered object has the tag "ring"
        if (isSuccessfulThrow)
        {
            // Log before destroying the object
            Debug.Log("Triggered with object tagged as ring: " + other.gameObject.name);

            // Increase the coin count
            if (coinCounter != null)
            {
                coinCounter.AddCoin();
                Debug.Log("Coin added successfully.");
            }
            else
            {
                Debug.LogWarning("CoinCounter reference is missing.");
            }

            // Destroy the object tagged as ring
            Debug.Log("Destroying object tagged as ring: " + other.gameObject.name);
            Destroy(other.gameObject);

            // Confirm the object destruction
            if (other == null)
            {
                Debug.Log("Object successfully destroyed.");
            }
            else
            {
                Debug.LogError("Object destruction failed.");
            }

            // Optionally, destroy the thrown object as well if needed
            // Debug.Log("Destroying thrown object: " + gameObject.name);
            // Destroy(gameObject);
        }
        else
        {
            Debug.Log("Triggered object is not tagged as ring, it is tagged as: " + other.gameObject.tag);
        }
    }
}
