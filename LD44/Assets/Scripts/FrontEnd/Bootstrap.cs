using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public List<Sprite> CardBgs;
    public GameObject RoomPrefab;
    public GameObject EntityPrefab;
    
    private void Start()
    {
        CardMB.CardBgs = CardBgs;
        RoomMB.RoomPrefab = RoomPrefab;
        EntityMB.EntityPrefab = EntityPrefab;

        new Player();

        Deck.Draws = new List<Card>
        {
            new TestCard(),
            new TestCard(),
            new BuffCard()
        };
        
        GameObject g = new GameObject();
        RoomMB r = g.AddComponent<RoomMB>();
        RoomMB.ActiveRoom = r;
        r.Init(new BattleRoom(), RoomType.BattleRoom);
    }
}