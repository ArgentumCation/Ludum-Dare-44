using System.Collections.Generic;
using UnityEngine;

public class Deck
{
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
