using UnityEngine;

public class CardMB : MonoBehaviour
{
    private Card _meCard;
    private Vector2 _targetPos;
    private bool _dragging;

    public void Init(Card c, Vector2 pos)
    {
        _meCard = c;
        transform.position = pos;
    }

    private void Update()
    {
        if (_dragging)
        {
            Vector3 mouseScreenPos = CameraMB.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseScreenPos.x, mouseScreenPos.y, -2);
        }
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, 1f);
    }

    private void OnMouseDown()
    {
        _dragging = true;
    }

    private void OnMouseUp()
    {
        _dragging = false;
        if (transform.position.y > 3)
            BattleActionManager.Click(_meCard);
        else
        {
            Deck.InsertIntoHand(this);
        }
    }

    public void SetTargetPos(Vector2 target)
    {
        _targetPos = target;
    }
}