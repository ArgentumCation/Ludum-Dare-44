using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class CardCountMB : MonoBehaviour
{
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.text = "Draws: " + Deck.Draws.Count + "\tDiscards: " + Deck.Discards.Count;
    }
}
