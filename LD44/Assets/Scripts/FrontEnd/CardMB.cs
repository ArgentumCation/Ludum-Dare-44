using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardMB : MonoBehaviour
{
    public static List<Sprite> CardBgs = new List<Sprite>();

    public Card MeCard;
    private Vector3 _targetPos;
    private bool _dragging;
    private const float SlideSpeed = 15;

    public void Init(Card c, Vector2 pos)
    {
        MeCard = c;
        transform.position = pos;
        _targetPos = pos;
        name = "Card";
    }

    private void Update()
    {
        if (_dragging)
        {
            Vector3 mouseScreenPos = CameraMB.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseScreenPos.x, mouseScreenPos.y, -2);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPos, SlideSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        _dragging = true;
        Deck.Hand.Remove(this);
    }

    private void OnMouseUp()
    {
        _dragging = false;
        if (transform.position.y > 3)
        {
            BattleActionManager.Click(this);
            _targetPos = new Vector3(8, 3, -0.5f);
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else
        {
            BattleActionManager.ClearActive();
            Deck.InsertIntoHand(this);
            transform.localScale = new Vector2(0.25f, 0.25f);
        }
    }

    public void SetTargetPos(Vector2 target)
    {
        _targetPos = target;
    }

    public void DestroyCard()
    {
        Destroy(gameObject);
    }

    public static CardMB Spawn(Card c)
    {
        GameObject cardObject = new GameObject();
        cardObject.transform.localScale = new Vector2(0.25f, 0.25f);
        
        CardMB cardMb = cardObject.AddComponent<CardMB>();
        SpriteRenderer cardSpriteRenderer = cardObject.AddComponent<SpriteRenderer>();
        BoxCollider2D boxCollider2D = cardObject.AddComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(8, 10);
        
        switch (c.GetCardType())
        {
            case CardType.AttackCard:
                cardSpriteRenderer.sprite = CardBgs[0];
                break;
            case CardType.BuffCard:
                cardSpriteRenderer.sprite = CardBgs[1];
                break;
            case CardType.HealingCard:
                cardSpriteRenderer.sprite = CardBgs[2];
                break;
            case CardType.SummonCard:
                cardSpriteRenderer.sprite = CardBgs[3];
                break;
            default:
                throw new ArgumentException("Invalid card: " + c.GetType().FullName);
        }

        GameObject textObject = new GameObject("Text");
        textObject.transform.parent = cardObject.transform;
        textObject.transform.position = new Vector3(-2.5f, -1, -0.1f);
        TextMeshPro text = textObject.AddComponent<TextMeshPro>();
        RectTransform rect = textObject.GetComponent<RectTransform>();
        text.fontSize = 5;
        text.color = Color.black;
        rect.localScale = Vector3.one;
        rect.localPosition = new Vector3(0, -2.4f, 0);
        rect.sizeDelta = new Vector2(5.25f, 3f);
        string[] textLines = c.Description.Split('\n');
        text.text = string.Format("<b>{0}</b>\n<i>{1}</i>\n{2}", textLines);

        cardMb.Init(c, new Vector2(HandMB.CalculatePos(Deck.Hand.Count), 1.5f));

        return cardMb;
    }
}