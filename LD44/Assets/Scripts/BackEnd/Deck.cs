using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Deck
{
    public static List<Card> Draws = new List<Card>();

    public static List<Card> Discards = new List<Card>();

    public static List<CardMB> Hand = new List<CardMB>();

    public static void DrawCard()
    {
        // if Draws empty, shuffle discard and put into Draws
        if (Draws.Count == 0)
        {
            Shuffle(Discards);
            Draws = Discards;
            Discards = new List<Card>();
        }

        CardMB newCard = CardMB.Spawn(Draws[0]);
        Hand.Add(newCard);
        Draws.RemoveAt(0);
    }

    public static void Discard(CardMB cardMb)
    {
        if (!Hand.Contains(cardMb))
            throw new Exception("Card isnt able to be discarded");

        Hand.Remove(cardMb);
        Discards.Add(cardMb.MeCard);
    }

    public static void InsertIntoHand(CardMB cardMb)
    {
        float cardMbX = cardMb.transform.position.x;
        for (int i = 0; i < Hand.Count; i++)
            if (cardMbX < HandMB.CalculatePos(i))
            {
                Hand.Insert(i, cardMb);
                return;
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
