using TMPro;
using UnityEngine;

public class CardCountMB : MonoBehaviour
{
    private TextMeshPro _text;

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    private void Update()
    {
        _text.text = "Draws: " + Deck.Draws.Count + "\tDiscards: " + Deck.Discards.Count + "\t  Score: " + Player.PlayerRef.RoomCount;
    }
}
