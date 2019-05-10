using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    public static Music MusicRef;
    public List<AudioClip> songs;
    private AudioSource _audioSource;
    private float _maxVolume;

    private void Start()
    {
        MusicRef = this;
        DontDestroyOnLoad(gameObject);
        
        _audioSource = GetComponent<AudioSource>();
        _maxVolume = _audioSource.volume;
        
        SetSong(0);
    }

    public static void Stop()
    {
        MusicRef._audioSource.Stop();
    }
    
    public void SetSong(int n)
    {
        MusicRef.StopAllCoroutines();
        foreach (AudioSource audioSource in MusicRef.GetComponents<AudioSource>())
            if (_audioSource != audioSource)
                Destroy(_audioSource);
        
        AudioSource newSource = MusicRef.gameObject.AddComponent<AudioSource>();
        newSource.volume = 0.0f;
        newSource.loop = true;
        newSource.clip = songs[n];
        newSource.Play();
        
        MusicRef.StartCoroutine(CrossFade(_audioSource, newSource, 0.5f));
        _audioSource = newSource;
    }

    private IEnumerator CrossFade(AudioSource oldSource, AudioSource newSource, float fadeTime)
    {
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            oldSource.volume = Mathf.Lerp(_maxVolume,0.0f,t/fadeTime);
            newSource.volume = Mathf.Lerp(0.0f,_maxVolume,t/fadeTime);

            yield return null;
        }

        newSource.volume = _maxVolume;
        Destroy(oldSource);
    }
}
