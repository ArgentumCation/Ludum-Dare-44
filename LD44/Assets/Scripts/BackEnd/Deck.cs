using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deck
{
    public static List<Sprite> CardBgs;
    
    public static List<Card> Draws;

    public static List<Card> Discards;

    public static List<CardMB> Hand;

    public static Card DrawCard()
    {
        // if Draws empty, shuffle discard and put into Draws
        if(Draws.Count == 0)
        {
            Shuffle(Discards);
            Draws = Discards;
            Discards = new List<Card>();
        }

        GameObject cardObject = new GameObject();
        CardMB cardMb = cardObject.AddComponent<CardMB>();
        SpriteRenderer cardSpriteRenderer = cardObject.AddComponent<SpriteRenderer>();
        if (Draws[0].GetType() == typeof(AttackCard))
            cardSpriteRenderer.sprite = CardBgs[0];
        else if (Draws[0].GetType() == typeof(BuffCard))
            cardSpriteRenderer.sprite = CardBgs[1];
        else if (Draws[0].GetType() == typeof(HealingCard))
            cardSpriteRenderer.sprite = CardBgs[2];
        else if (Draws[0].GetType() == typeof(SummonCard))
            cardSpriteRenderer.sprite = CardBgs[3];
        else
            throw new ArgumentException("Invalid card: " + Draws[0].GetType().FullName);
        
        cardMb.Init(Draws[0], new Vector2(HandMB.CalculatePos(Hand.Count), 1.5f));
        Hand.Add(cardMb);

        return Draws[0];
    }

    public static void Discard(CardMB cardMb)
    {
        if (!Hand.Contains(cardMb))
        {
            throw new System.Exception("Card isnt able to be discarded");
        }

        Hand.Remove(cardMb);
        Discards.Add(cardMb.MeCard);
    }

    public static void InsertIntoHand(CardMB cardMb)
    {
        float cardMbX = cardMb.transform.position.x;
        for (int i = 0; i < Hand.Count; i++)
        {
            if (cardMbX < HandMB.CalculatePos(i))
            {
                Hand.Insert(i, cardMb);
                return;
            }
        }
        Hand.Add(cardMb);
    }

    public static void Shuffle(List<Card> list)
    {
        int listCount = list.Count;
        for (int i = 0; i < listCount; i++)
        {
            int j = Random.Range(i, listCount - 1);
            Card temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
