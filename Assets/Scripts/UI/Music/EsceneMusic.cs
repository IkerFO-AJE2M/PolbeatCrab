using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsceneMusic : MonoBehaviour
{
    public AudioClip sceneMusic;
    public bool loop = true;

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic(sceneMusic, loop);
        }
    }
}
