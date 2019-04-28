using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleActionManager
{
    public static BattleActionState State;
    private static CardMB _activeCard;
    private static List<Entity> _targets = new List<Entity>();

    public static void Init()
    {
        _activeCard = null;
        _targets.Clear();
        State = BattleActionState.SelectCard;
    }

    public static void ClearActive()
    {
        if (State == BattleActionState.HandleTurn)
            return;

        _activeCard = null;
        _targets.Clear();
        State = BattleActionState.SelectCard;
    }
    
    public static void Click(CardMB cardMb)
    {
        if (State != BattleActionState.SelectCard)
            return;

        _activeCard = cardMb;
        State = BattleActionState.SelectTargets;
    }

    public static void Click(Entity entity)
    {
        if (State != BattleActionState.SelectTargets || _activeCard == null)
            return;
        
        _targets.Add(entity);

        if (_activeCard.MeCard.NumTargets < _targets.Count)
            return;

        State = BattleActionState.HandleTurn;
        if (_activeCard.MeCard.NumTargets > _targets.Count)
        {
            Debug.Log("Too many targets! Card: " + _activeCard.GetType().FullName);
            _activeCard.MeCard.Cast(_targets.Take(_activeCard.MeCard.NumTargets).ToList());
        }
        else if (_activeCard.MeCard.NumTargets == _targets.Count)
        {
            _activeCard.MeCard.Cast(_targets);
        }
        Deck.Discards.Add(_activeCard.MeCard);
        _activeCard.DestroyCard();
        _activeCard = null;
        _targets.Clear();
        Deck.DrawCard();
        State = BattleActionState.SelectCard;
    }
}
