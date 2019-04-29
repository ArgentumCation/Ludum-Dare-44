using UnityEngine;

public class ArtifactRoom : Room
{
    public override void Enter()
    {
        Object.Instantiate(AddCardMB.AddCardPrefab);
    }
}
