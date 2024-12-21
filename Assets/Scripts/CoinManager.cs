using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; } // Singleton untuk akses global

    private int coinCount = 0; // Total jumlah koin
    private Text coinDisplayText; // Referensi ke UI Text untuk tampilan jumlah koin

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Tetapkan Singleton
            DontDestroyOnLoad(gameObject); // Jangan hancurkan saat pindah scene
            SceneManager.sceneLoaded += OnSceneLoaded; // Tambahkan listener untuk scene baru
        }
        else
        {
            Destroy(gameObject); // Hancurkan duplikat
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Hapus listener saat CoinManager dihancurkan
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindCoinDisplay(); // Cari elemen UI untuk tampilan koin
        UpdateCoinDisplay(); // Perbarui tampilan dengan jumlah koin saat ini
    }

    public void AddCoin(int amount)
    {
        coinCount += amount; // Tambahkan jumlah koin
        UpdateCoinDisplay(); // Perbarui tampilan UI
    }

    public void SetCoinDisplayText(Text newDisplayText)
    {
        coinDisplayText = newDisplayText; // Atur elemen UI baru
        UpdateCoinDisplay(); // Perbarui tampilan dengan nilai saat ini
    }

    public int GetCoinCount()
    {
        return coinCount; // Ambil jumlah koin saat ini
    }

    private void UpdateCoinDisplay()
    {
        if (coinDisplayText != null)
        {
            coinDisplayText.text = coinCount.ToString(); // Perbarui teks tampilan jumlah koin
        }
        else
        {
            Debug.LogWarning("UI Text untuk tampilan koin belum diatur.");
        }
    }

    private void FindCoinDisplay()
    {
        // Cari elemen Text dengan nama "CoinText" di scene baru
        coinDisplayText = GameObject.Find("CoinText")?.GetComponent<Text>();
        if (coinDisplayText == null)
        {
            Debug.LogWarning("CoinText tidak ditemukan di scene ini.");
        }
        else
        {
            Debug.Log("CoinText berhasil ditemukan di scene ini.");
        }
    }

    public int GetTotalCoins()
    {
        return coinCount; // Ambil jumlah total koin
    }
}
