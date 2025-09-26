using Gameplay;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(AudioSource))]
public class AudioObject : MonoBehaviour, IPoolableObjects
{
    AudioSource audioSource;
    public void BackToPool()
    {
        gameObject.SetActive(false);

    }

    public void Init(ObjectPooling pool)
    {
        if(audioSource == null) audioSource = GetComponent<AudioSource>();
        gameObject.SetActive(true);
    }

    public void PlaySound(AudioClip audioClip ,float pitch)
    {
        audioSource.pitch = pitch;
        PlaySound(audioClip);
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
