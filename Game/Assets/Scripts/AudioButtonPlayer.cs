using UnityEngine;

public class AudioButtonPlayer : MonoBehaviour
{
    public AudioSource audioSource; // ��קAudioSource
    public AudioClip clip;          // ��ק��Ƶ�ļ�

    public void PlaySound()
    {
        if (audioSource && clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}