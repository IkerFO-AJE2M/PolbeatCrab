using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;

    private Stack<MusicState> musicStack = new Stack<MusicState>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Cargar volumen guardado
            AudioListener.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }
    
    [System.Serializable]
    public class MusicState
    {
        public AudioClip clip;
        public float time;

        public MusicState(AudioClip c, float t)
        {
            clip = c;
            time = t;
        }
    }
    public void PushMusic(AudioClip newClip, bool loop = true)
    {
        if (musicSource.clip != null)
            musicStack.Push(new MusicState(musicSource.clip, musicSource.time));

        musicSource.clip = newClip;
        musicSource.loop = loop;
        musicSource.Play(); // puedes opcionalmente Play desde 0 o desde un tiempo inicial que quieras
    }
    public void PopMusic()
    {
        if (musicStack.Count > 0)
        {
            MusicState previous = musicStack.Pop();
            musicSource.clip = previous.clip;
            musicSource.loop = true;
            musicSource.time = previous.time; 
            musicSource.Play();
        }
    }
}
