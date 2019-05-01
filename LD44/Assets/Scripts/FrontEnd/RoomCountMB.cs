using TMPro;
using UnityEngine;

public class RoomCountMB : MonoBehaviour
{
    private TextMeshPro _text;

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        _text.text = "Room: " + RoomGenerator.TotalRooms;
    }
}
