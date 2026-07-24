using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
                audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
           
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}