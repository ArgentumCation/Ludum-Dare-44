using UnityEngine;

public class FountainMB : MonoBehaviour
{
    public static GameObject FountainPrefab;
    
    public ButtonMB YesButton;
    public ButtonMB NoButton;
    
    private void Start()
    {
        YesButton.OnClick = Accept;
        NoButton.OnClick = Reject;
    }

    private void Accept()
    {
        Player.PlayerRef.UseFountain();
        RoomMB.ActiveRoom.Exit();
        Destroy(gameObject);
    }
    
    private void Reject()
    {
        RoomMB.ActiveRoom.Exit();
        Destroy(gameObject);
    }
}
