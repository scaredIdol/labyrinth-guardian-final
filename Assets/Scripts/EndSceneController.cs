using UnityEngine;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] private Text totalCoinsText; // Referensi ke UI Text untuk jumlah koin

    private void Start()
    {
        if (CoinManager.Instance != null)
        {
            Debug.Log("CoinManager ditemukan.");
            int totalCoins = CoinManager.Instance.GetTotalCoins(); // Ambil jumlah total koin
            totalCoinsText.text = "" + totalCoins; // Perbarui teks
        }
        else
        {
            Debug.LogWarning("CoinManager tidak ditemukan.");
            totalCoinsText.text = "Total Coins Collected: 0"; // Default jika CoinManager tidak ditemukan
        }
    }
}
