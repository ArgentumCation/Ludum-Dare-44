using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
