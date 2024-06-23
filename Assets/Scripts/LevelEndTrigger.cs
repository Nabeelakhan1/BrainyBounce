using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public int currentLevelIndex;  // The index of the current level

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            LevelCompletion levelCompletion = FindObjectOfType<LevelCompletion>();
            if (levelCompletion != null)
            {
                levelCompletion.OnLevelComplete(currentLevelIndex);
            }
        }
    }
}
