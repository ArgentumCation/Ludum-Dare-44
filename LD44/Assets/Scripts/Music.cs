using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music musicRef;
    public List<AudioClip> songs;
    private AudioSource _audioSource;

    private void Start()
    {
        musicRef = this;
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = songs[0];
    }

    public void SetSong(int n)
    {
        _audioSource.clip = songs[n];
    }
}
