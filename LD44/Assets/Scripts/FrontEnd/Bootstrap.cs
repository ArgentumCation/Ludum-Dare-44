using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public List<Sprite> CardBgs;
    
    private void Start()
    {
        CardMB.CardBgs = CardBgs;

        Deck.Draws = new List<Card>
        {
            new BuffCard(),
            new BuffCard(),
            new AttackCard()
        };
        Deck.DrawCard();
        Deck.DrawCard();
        Deck.DrawCard();
    }
}