using UnityEngine;

public class RoomGenerator
{
    public static int MinBattlesSinceFountain = 3;
    public static int BattlesSinceFountain;
    public static int BattlesSinceArtifact;
    public static int TotalRooms;

    public static void GenerateRoom()
    {
        TotalRooms++;
        GameObject roomObjcet = Object.Instantiate(RoomMB.RoomPrefab);
        RoomMB roomMb = roomObjcet.GetComponent<RoomMB>();
        if (TotalRooms > 50)
        {
            if (TotalRooms == 51)
            {
                roomMb.Init(RoomType.FountainRoom);
            }
            else if (TotalRooms == 52)
            {
                //TODO boss room
            }
            else
            {
                // TODO win
            }
        }
        else if (BattlesSinceFountain > MinBattlesSinceFountain)
        {
            if (Random.value > 0.8)
                MinBattlesSinceFountain++;

            if (Random.value > 0.3)
            {
                roomMb.Init(RoomType.FountainRoom);
            }
        }
        else if (BattlesSinceArtifact > 5)
        {
            if (Random.value > 0.8)
            {
                BattlesSinceArtifact = 0;
                roomMb.Init(RoomType.ArtifactRoom);
            }
        }
        else
        {
            BattlesSinceFountain++;
            BattlesSinceArtifact++;
            roomMb.Init(RoomType.BattleRoom);
        }
    }
}
