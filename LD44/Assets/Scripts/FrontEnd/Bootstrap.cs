using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public List<Sprite> CardBgs;
    public GameObject EntityPrefab;
    public GameObject RoomPrefab;

    private void Start()
    {
        CardMB.CardBgs = CardBgs;
        RoomMB.RoomPrefab = RoomPrefab;
        EntityMB.EntityPrefab = EntityPrefab;

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

        GameObject g = new GameObject();
        RoomMB r = g.AddComponent<RoomMB>();
        RoomMB.ActiveRoom = r;
        r.Init(new BattleRoom(), RoomType.BattleRoom);
    }
}
