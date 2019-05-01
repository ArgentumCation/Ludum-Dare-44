using UnityEngine;

public class RoomGenerator
{
    public static int MinBattlesSinceFountain = 2;
    public static int BattlesSinceFountain;
    public static int BattlesSinceArtifact;
    public static int TotalRooms;

    public static void GenerateRoom()
    {
        TotalRooms++;
        GameObject roomObject = Object.Instantiate(RoomMB.RoomPrefab);
        RoomMB roomMb = roomObject.GetComponent<RoomMB>();
        if (TotalRooms > 50)
        {
            if (TotalRooms < 54)
            {
                roomMb.Init(RoomType.FountainRoom);
            }
            else if (TotalRooms == 54)
            {
                Music.musicRef.SetSong(2);
                roomMb.Init(RoomType.BossRoom);
            }
            else
            {
                BattleManager.EndGameObject.SetActive(true);
                BattleManager.EndGameObject.GetComponent<EndGameMB>().Activate(true);
            }
        }
        else if (BattlesSinceFountain >= MinBattlesSinceFountain)
        {

            if (Random.value > 0.3)
            {
                if (Random.value > 0.8)
                    MinBattlesSinceFountain++;
                
                BattlesSinceFountain = 0;
                roomMb.Init(RoomType.FountainRoom);
            }
        }
        else if (Random.value > 0.9)
        {
            BattlesSinceArtifact = 0;
            roomMb.Init(RoomType.ArtifactRoom);
        }
        else
        {
            BattlesSinceFountain++;
            BattlesSinceArtifact++;
            roomMb.Init(RoomType.BattleRoom);
        }
    }
}
