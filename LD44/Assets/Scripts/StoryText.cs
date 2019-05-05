using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryText : MonoBehaviour
{
    public List<GameObject> Texts;
    public const float Seconds = 2;
    private float _progression;

    private void Start()
    {
        foreach (GameObject text in Texts)
            text.SetActive(false);
    }

    private void Update()
    {
        int textCount = Texts.Count;
        if (Input.GetKeyDown(KeyCode.S))
        {
            RoomGenerator.RoomsUntilBoss = 6;
        }
        // Skips story
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("InGame");
        }
        if (_progression < textCount - 1)
        {
            _progression += Time.deltaTime / Seconds;
            for (int i = 0; i < _progression; i++)
                Texts[i].SetActive(true);
        }
        else
        {
            _progression += Time.deltaTime;
            if (_progression - textCount > 6)
            {
                Music.musicRef.SetSong(1);
                SceneManager.LoadScene("InGame");
            }
        }
    }
}
