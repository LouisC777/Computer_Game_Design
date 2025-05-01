using UnityEngine;

public class AudioButtonPlayer : MonoBehaviour
{
    public AudioSource audioSource; // ÍÏ×§AudioSource
    public AudioClip clip;          // ÍÏ×§ÒôÆµÎÄ¼þ

    public void PlaySound()
    {
        if (audioSource && clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}