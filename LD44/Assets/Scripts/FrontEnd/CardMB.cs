using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardMB : MonoBehaviour
{
    public static List<Sprite> CardBgs = new List<Sprite>();
    public static GameObject CardPrefab;

    public SpriteRenderer CardSprite;
    public SpriteRenderer CardArt;
    
    private bool _dragging;
    
    private Vector3 _targetPos;
    private const float SlideSpeed = 15;

    public Card MeCard;

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
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Deck.Hand.Remove(this);
    }

    private void OnMouseUp()
    {
        _dragging = false;
        if (transform.position.y > 3 && BattleActionManager.State == BattleActionState.SelectCard)
        {
            BattleActionManager.Click(this);
            _targetPos = new Vector3(8, 3, -0.5f);
        }
        else
        {
            BattleActionManager.ClearActive();
            Deck.InsertIntoHand(this);
            transform.localScale = new Vector3(0.25f, 0.25f, 1);
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
        GameObject cardObject = Instantiate(CardPrefab);
        CardMB cardMb = cardObject.GetComponent<CardMB>();
        
        switch (c.GetCardType())
        {
            case CardType.AttackCard:
                cardMb.CardSprite.sprite = CardBgs[0];
                break;
            case CardType.BuffCard:
                cardMb.CardSprite.sprite = CardBgs[1];
                break;
            case CardType.HealingCard:
                cardMb.CardSprite.sprite = CardBgs[2];
                break;
            case CardType.SummonCard:
                cardMb.CardSprite.sprite = CardBgs[3];
                break;
            default:
                throw new ArgumentException("Invalid card: " + c.GetType().FullName);
        }

        cardMb.CardArt.sprite = c.CardArt;
        
        TextMeshPro text = cardObject.GetComponentInChildren<TextMeshPro>();
        string[] textLines = c.Description.Split('\n');
        text.text = string.Format("<b>{0}</b>\n<i>{1}</i>\n{2}", textLines);

        cardMb.Init(c, new Vector2(HandMB.CalculatePos(Deck.Hand.Count), 1.5f));

        return cardMb;
    }
}
