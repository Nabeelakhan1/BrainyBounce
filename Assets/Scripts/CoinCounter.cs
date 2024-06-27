using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Use TextMeshProUGUI for TextMeshPro
    // public Text coinText; // Uncomment this if you're using the standard UI Text
    private int coinCount = 0;

    void Start()
    {
        // Set overflow modes programmatically (for TextMeshPro)
        coinText.enableWordWrapping = false;
        coinText.overflowMode = TextOverflowModes.Overflow;

        // For standard UI Text, ensure overflow is set in the Inspector.

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
}
