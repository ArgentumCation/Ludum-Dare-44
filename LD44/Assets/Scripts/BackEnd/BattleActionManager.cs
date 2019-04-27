using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleActionManager
{
    public static BattleActionState State;
    private static Card _activeCard;
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
        State = BattleActionState.SelectCard;
    }
    
    public static void Click(Card card)
    {
        if (State != BattleActionState.SelectCard)
            return;

        _activeCard = card;
        State = BattleActionState.SelectTargets;
    }

    public static void Click(Entity entity)
    {
        if (State != BattleActionState.SelectTargets || _activeCard == null)
            return;
        
        _targets.Add(entity);

        if (_activeCard.NumTargets < _targets.Count)
            return;

        if (_activeCard.NumTargets > _targets.Count)
        {
            Debug.Log("Too many targets! Card: " + _activeCard.GetType().FullName);
            _activeCard.Cast(_targets.Take(_activeCard.NumTargets));
        }
        else if (_activeCard.NumTargets == _targets.Count)
        {
            _activeCard.Cast(_targets);
        }
        _activeCard = null;
        _targets.Clear();
        State = BattleActionState.HandleTurn;
    }
}
