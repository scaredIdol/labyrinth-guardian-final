using UnityEngine;

public class EndSceneMusicController : MonoBehaviour
{
    [SerializeField] private AudioClip endSceneMusic; // AudioClip untuk musik End Scene
    private AudioSource audioSource;

    private void Start()
    {
        // Ambil atau tambahkan AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Atur properti AudioSource
        audioSource.clip = endSceneMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.volume = 0.5f; // Sesuaikan volume

        // Mainkan musik
        audioSource.Play();
    }
}
