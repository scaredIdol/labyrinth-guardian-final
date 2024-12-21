using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound; // Sound effect koin
    private AudioSource audioSource;

    private void Start()
    {
        // Tambahkan AudioSource jika tidak ada
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AddCoin(1); // Tambahkan koin ke CoinManager
            }
            else
            {
                Debug.LogWarning("CoinManager tidak ditemukan.");
            }

            if (coinSound != null)
            {
                audioSource.PlayOneShot(coinSound); // Mainkan suara
            }

            Destroy(gameObject, 0.2f); // Hancurkan koin setelah sedikit delay
        }
    }
}
