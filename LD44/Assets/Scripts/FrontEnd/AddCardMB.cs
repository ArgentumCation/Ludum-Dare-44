using System;
using UnityEngine;

public class AddCardMB : MonoBehaviour
{
    public static GameObject AddCardPrefab;
    
    public GameObject CardTarget;
    
    private Card _card;
    private GameObject _cardObject;
    
    public ButtonMB YesButton;
    public ButtonMB NoButton;
    
    private void Start()
    {
        YesButton.OnClick = Accept;
        NoButton.OnClick = Reject;
        
        _card = (Card) Activator.CreateInstance(CardList.GetRandomCard());
        CardMB c = CardMB.Spawn(_card);
        _cardObject = c.gameObject;
        Destroy(c);
        _cardObject.transform.position = CardTarget.transform.position;
    }
    
    private void Accept()
    {
        Deck.Discards.Add(_card);
        RoomMB.ActiveRoom.Exit();
        Destroy(_cardObject);
        Destroy(gameObject);
    }
    
    private void Reject()
    {
        RoomMB.ActiveRoom.Exit();
        Destroy(_cardObject);
        Destroy(gameObject);
    }
}
