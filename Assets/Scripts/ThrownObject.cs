using UnityEngine;

public class ThrownObject : MonoBehaviour
{
    private CoinCounter coinCounter; // Reference to the CoinCounter script

    void Start()
    {
        // Find the CoinCounter in the scene
        coinCounter = FindObjectOfType<CoinCounter>();

        if (coinCounter == null)
        {
            Debug.LogError("CoinCounter not found in the scene. Please ensure there is a GameObject with a CoinCounter script.");
        }

        // Log the tag of this game object (the thrown object)
        Debug.Log("Thrown object tag: " + gameObject.tag);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Log collision information
        Debug.Log("Collision detected with: " + collision.gameObject.name + ", Tag: " + collision.gameObject.tag);

        // Check if the collided object has the tag "ring"
        if (collision.gameObject.CompareTag("ring"))
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

            // Confirm the object destruction
            if (collision.gameObject == null)
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
            Debug.Log("Collided object is not tagged as ring, it is tagged as: " + collision.gameObject.tag);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Log trigger information
        Debug.Log("Trigger detected with: " + other.gameObject.name + ", Tag: " + other.gameObject.tag);

        // Check if the triggered object has the tag "ring"
        if (other.CompareTag("ring"))
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

            // Destroy the object tagged as "ring"
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
