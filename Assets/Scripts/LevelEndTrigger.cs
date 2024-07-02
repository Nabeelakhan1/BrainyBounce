using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public int currentLevelIndex;  // The index of the current level
    public int requiredCoins;  // Number of coins required to complete the level
    public GameObject gameLosePanel;  // Panel to display when the player loses

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            CoinCounter coinCounter = FindObjectOfType<CoinCounter>();
            LevelCompletion levelCompletion = FindObjectOfType<LevelCompletion>();

            if (coinCounter != null && levelCompletion != null)
            {
                if (coinCounter.GetCoinCount() >= requiredCoins)
                {
                    levelCompletion.OnLevelComplete(currentLevelIndex);
                }
                else
                {
                    gameLosePanel.SetActive(true);
                    Time.timeScale = 0;  // Pause the game
                }
            }
        }
    }
}
