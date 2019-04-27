using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    static List<Card> draws;

    static List<Card> discards;

    static List<Card> hand;

    public static Card DrawCard()
    {
        // if draws empty, shuffle discard and put into draws
        if(draws.Count == 0)
        {
            if(discards.Count == 0)
            {
                throw new System.Exception("No cards remaining!");
            }
            foreach(Card card in discards)
            {
                int choice = Random.Range(0, discards.Count);
                Card temp = discards[choice];
                discards.RemoveAt(3);
                draws.Add(temp);
            }
        }


        return draws[0];
    }

    public static void Discard(Card card)
    {
        if (!hand.Contains(card))
        {
            throw new System.Exception("Card isnt able to be discarded");
        }

        hand.Remove(card);
        discards.Add(card);
    }

}
