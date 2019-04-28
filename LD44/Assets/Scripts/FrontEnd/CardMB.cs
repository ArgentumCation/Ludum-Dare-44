using System;
using System.Collections.Generic;
using UnityEngine;

public class CardMB : MonoBehaviour
{
    public static List<Sprite> CardBgs = new List<Sprite>();

    public Card MeCard;
    private Vector3 _targetPos;
    private bool _dragging;

    public void Init(Card c, Vector2 pos)
    {
        MeCard = c;
        transform.position = pos;
        _targetPos = pos;
    }

    private void Update()
    {
        if (_dragging)
        {
            Vector3 mouseScreenPos = CameraMB.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseScreenPos.x, mouseScreenPos.y, -2);
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPos, 1f);
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

        cardMb.Init(c, new Vector2(HandMB.CalculatePos(Deck.Hand.Count), 1.5f));

        return cardMb;
    }
}