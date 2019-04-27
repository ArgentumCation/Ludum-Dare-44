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
            BattleActionManager.Click(MeCard);
            _targetPos = new Vector3(8, 3, -0.5f);
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else
        {
            BattleActionManager.ClearActive();
            Deck.InsertIntoHand(this);
            transform.localScale = new Vector2(0.3f, 0.3f);
        }
    }

    public void SetTargetPos(Vector2 target)
    {
        _targetPos = target;
    }

    public static CardMB Spawn(Card c)
    {
        GameObject cardObject = new GameObject();
        cardObject.transform.localScale = new Vector2(0.3f, 0.3f);
        CardMB cardMb = cardObject.AddComponent<CardMB>();
        SpriteRenderer cardSpriteRenderer = cardObject.AddComponent<SpriteRenderer>();
        BoxCollider2D boxCollider2D = cardObject.AddComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(8, 10);
        if (c.GetType() == typeof(AttackCard))
            cardSpriteRenderer.sprite = CardBgs[0];
        else if (c.GetType() == typeof(BuffCard))
            cardSpriteRenderer.sprite = CardBgs[1];
        else if (c.GetType() == typeof(HealingCard))
            cardSpriteRenderer.sprite = CardBgs[2];
        else if (c.GetType() == typeof(SummonCard))
            cardSpriteRenderer.sprite = CardBgs[3];
        else
            throw new ArgumentException("Invalid card: " + c.GetType().FullName);
        
        cardMb.Init(c, new Vector2(HandMB.CalculatePos(Deck.Hand.Count), 1.5f));

        return cardMb;
    }
}