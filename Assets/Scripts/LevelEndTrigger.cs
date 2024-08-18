using TMPro;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public int currentLevelIndex;  
    public int requiredCoins; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            CoinCounter coinCounter = FindObjectOfType<CoinCounter>();
            LevelCompletion levelCompletion = FindObjectOfType<LevelCompletion>();

            if (coinCounter != null && levelCompletion != null)
            {

                //CoinCounter is script, GetCoinCount is its method
                bool isWin = coinCounter.GetCoinCount() >= requiredCoins;

                //levelCompletion is script, OnLevelComplete is 
                levelCompletion.OnLevelComplete(currentLevelIndex, isWin);
            }
        }
    }
}