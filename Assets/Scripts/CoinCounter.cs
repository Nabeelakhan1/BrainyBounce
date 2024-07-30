using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Use TextMeshProUGUI for TextMeshPro
    public int totalCoinsToCollect; // Total number of coins to be collected
    private int coinCount = 0;

    void Start()
    {
        coinText.enableWordWrapping = false;
        coinText.overflowMode = TextOverflowModes.Overflow;
        UpdateCoinText();
    }

    public void AddCoin()
    {
        if (coinCount < totalCoinsToCollect)
        {
            coinCount++;
            UpdateCoinText();
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = "" + coinCount;
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
