using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public List<Sprite> CardBgs;
    
    private void Start()
    {
        Deck.CardBgs = CardBgs;
        
        Deck.Draws = new List<Card>();
        Deck.Draws.Add(new BuffCard());
        Deck.DrawCard();
    }
}