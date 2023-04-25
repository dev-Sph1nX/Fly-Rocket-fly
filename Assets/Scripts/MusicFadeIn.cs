using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeIn : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float fadeDuration = 3.0f;
    [SerializeField] float maxVolume = 0.2f;

    void Start()
    {
        audioSource.volume = 0;
    }

    void Update()
    {
        float newVolume = Mathf.Lerp(audioSource.volume, maxVolume, fadeDuration);
        audioSource.volume = newVolume;
    }
}
