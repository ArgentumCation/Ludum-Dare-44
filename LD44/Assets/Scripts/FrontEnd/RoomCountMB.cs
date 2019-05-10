using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class RoomCountMB : MonoBehaviour
{
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.text = "Room: " + RoomGenerator.TotalRooms;
    }
}
