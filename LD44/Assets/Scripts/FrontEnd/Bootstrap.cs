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
            //new TestCard(),
            //new TestCard(),
            new BuffCard(),
            new ComboStrike(),
            new HealingBeam(),
            new Jab(),
            new HammerThrust(),
            new Punch(),
            new BloodBeam(),
            new Assassination(),
            new DoubleStrike(),
            new LeechingArrow(),
            new LesserHealing(),
            new RoundhouseKick(),
            new Punch()
        };

        Deck.Shuffle(Deck.Draws);

        Deck.DrawCard();
        Deck.DrawCard();
        Deck.DrawCard();
        
        RoomGenerator.GenerateRoom();
    }
}
