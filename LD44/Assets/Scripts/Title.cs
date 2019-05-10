using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private void OnMouseDown()
    {
        Music.MusicRef.SetSong(3);
        SceneManager.LoadScene("Disclaimer");
    }
}
