using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public GameObject CardPrefab;
    
    private void Start()
    {
        Deck.CardPrefab = CardPrefab;
    }
}