using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Use TextMeshProUGUI for TextMeshPro
    private int coinCount = 0;

    void Start()
    {
        coinText.enableWordWrapping = false;
        coinText.overflowMode = TextOverflowModes.Overflow;
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinText();
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
