using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshPro))]
public class Disclaimer : MonoBehaviour
{
    private TextMeshPro _text;
    private float _time;
    public float TotalTime = 4;

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > TotalTime)
            SceneManager.LoadScene("Story");

        Color c = _text.color;
        c.a = Mathf.Clamp(TotalTime - Mathf.Abs(_time - TotalTime), 0, 1);
    }
}
