using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private void OnMouseDown()
    {
        Music.musicRef.SetSong(3);
        SceneManager.LoadScene("Story");
    }
}
