using System.Collections;
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
        SetSong(0);
    }

    public static void Stop()
    {
        musicRef._audioSource.Stop();
    }
    
    public void SetSong(int n)
    {
        musicRef.StopAllCoroutines();
        if (musicRef.GetComponents<AudioSource>().Length > 1)
        {
            Destroy(musicRef.GetComponent<AudioSource>());
        }
        AudioSource newSource = musicRef.gameObject.AddComponent<AudioSource>();
        newSource.volume = 0.0f;
        newSource.loop = true;
        newSource.clip = songs[n];
        newSource.Play();
        musicRef.StartCoroutine(CrossFade(newSource, 0.5f));
        //_audioSource.clip = songs[n];
        //_audioSource.Play();
    }

    
    //PRobably VERY Laggy
    IEnumerator CrossFade(AudioSource newSource, float fadeTime)
    {
        float t = 0.0f;
        AudioSource source = GetComponent<AudioSource>();
        float initialVolume = source.volume;

        while(t < fadeTime)
        {
            source.volume = Mathf.Lerp(initialVolume,0.0f,t/fadeTime);
            newSource.volume = Mathf.Lerp(0.0f,initialVolume,t/fadeTime);

            t += Time.deltaTime;
            yield return null;
        }

        newSource.volume = initialVolume;

        Destroy(source);
    }

}
