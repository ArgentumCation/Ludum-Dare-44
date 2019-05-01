using TMPro;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    private TextMeshPro _text;
    private float _transparency;
    
    private void Awake()
    {
        _text = GetComponent<TextMeshPro>();
        Color c = _text.color;
        c.a = 0;
        _text.color = c;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_transparency < 1)
        {
            _transparency = Mathf.Clamp(_transparency + Time.deltaTime / StoryText.Seconds, 0, 1);
            Color c = _text.color;
            c.a = _transparency;
            _text.color = c;
        }
    }
}
