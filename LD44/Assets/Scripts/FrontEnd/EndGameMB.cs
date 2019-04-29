using UnityEngine;

public class EndGameMB : MonoBehaviour
{
    public Sprite WinSprite;
    public Sprite LoseSprite;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.material.color = new Color(1, 1, 1, 0);
        gameObject.SetActive(false);
    }

    public void Activate(bool win)
    {
        if (win)
        {
            _spriteRenderer.sprite = WinSprite;
        }
        else
        {
            _spriteRenderer.sprite = LoseSprite;
        }
    }

    private void Update()
    {
        Material material = _spriteRenderer.material;
        Color c = material.color;
        c.a += Time.deltaTime * 0.5f;
        if (c.a > 7)
            Application.Quit();
        material.color = c;
    }
}
