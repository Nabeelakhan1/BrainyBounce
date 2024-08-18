using UnityEngine;

public class ThrownObject : MonoBehaviour
{
    private CoinCounter coinCounter; // Reference to the CoinCounter script
    private LevelCompletion levelCompletion; // Reference to the LevelCompletion script
    public AudioClip ringCollisionSound;
    public AudioClip WaterCollisionSound;
    private AudioSource audioSource;
    

    void Start()
    {
        coinCounter = FindObjectOfType<CoinCounter>();
        levelCompletion = FindObjectOfType<LevelCompletion>();
        audioSource=GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject collidedObject)
    {
        if(gameObject.CompareTag("bullet")&&collidedObject.CompareTag("water"))
        {
            playSound(WaterCollisionSound);
        }
        if (gameObject.CompareTag("bullet") && collidedObject.CompareTag("ring"))
        {
            //
            
            // Track the throw
            if (levelCompletion != null)
            {
                levelCompletion.TrackThrow(true);
            }

            // Increase the coin count
            if (coinCounter != null)
            {
                coinCounter.AddCoin();
                Debug.Log("Coin added successfully.");
                //playSound(ringCollisionSound);
            }
            else
            {
                Debug.LogWarning("CoinCounter reference is missing.");
            }

            // Destroy the object tagged as ring
            Debug.Log("Destroying object tagged as ring: " + collidedObject.name);
            Destroy(collidedObject);
            playSound(ringCollisionSound);
        }
        else
        {
            Debug.Log("Collided object is not tagged as ring, it is tagged as: " + collidedObject.tag);
        }
    }

    public void playSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
