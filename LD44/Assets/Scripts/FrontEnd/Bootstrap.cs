using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public List<Sprite> CardBgs;
    public GameObject CardPrefab;
    public GameObject EntityPrefab;
    public GameObject RoomPrefab;
    public GameObject AddCardPrefab;
    public GameObject FountainPrefab;
    public GameObject EndGameObject;

    private void Start()
    {
        CardMB.CardBgs = CardBgs;
        CardMB.CardPrefab = CardPrefab;
        RoomMB.RoomPrefab = RoomPrefab;
        EntityMB.EntityPrefab = EntityPrefab;
        AddCardMB.AddCardPrefab = AddCardPrefab;
        FountainMB.FountainPrefab = FountainPrefab;
        BattleManager.EndGameObject = EndGameObject;

        new Player();

        Deck.Draws = new List<Card>
        {
            new Punch(),
            new ComboStrike(),
            new HealingBeam(),
            // Top three will always be drawn first turn but after that, shuffle.
            new LesserHealing(),
            new Jab(),
            new HammerThrust(),
            new Punch(),
            new Punch()
        };

        Deck.DrawCard();
        Deck.DrawCard();
        Deck.DrawCard();
        
        Deck.Shuffle(Deck.Draws);
        
        RoomGenerator.GenerateRoom();
    }
}
