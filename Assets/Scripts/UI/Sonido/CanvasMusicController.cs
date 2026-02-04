using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMusicController : MonoBehaviour
{

    public AudioClip canvasMusic;

    void OnEnable()
    {
        if (AudioManager.Instance != null && canvasMusic != null)
            AudioManager.Instance.PushMusic(canvasMusic);
    }

    void OnDisable()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PopMusic();
    }
}
