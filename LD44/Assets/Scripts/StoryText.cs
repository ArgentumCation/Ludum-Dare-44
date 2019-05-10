using System.Collections.Generic;
using TMPro;
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
        if (RoomGenerator.RoomsUntilBoss == 10)
        {
            Texts[0].GetComponent<TextMeshPro>().color = Color.red;
        }
        int textCount = Texts.Count;
        // Enables Showcase Mode
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (RoomGenerator.RoomsUntilBoss == 10)
            {
                RoomGenerator.RoomsUntilBoss = 50;
            }
            else
            {
                RoomGenerator.RoomsUntilBoss = 10;
            }
            
        }
        // Skips story
        if (Input.anyKeyDown)
        {   
            Music.MusicRef.SetSong(1);
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
                Music.MusicRef.SetSong(1);
                SceneManager.LoadScene("InGame");
            }
        }
    }
}
