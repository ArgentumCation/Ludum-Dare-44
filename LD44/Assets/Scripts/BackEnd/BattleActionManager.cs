using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class BattleActionManager
{
    public static BattleActionState State = BattleActionState.HandleTurn;
    private static CardMB _activeCard;
    private static List<Entity> _targets = new List<Entity>();

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

        if (_activeCard.MeCard.NumTargets > _targets.Count)
            return;

        State = BattleActionState.HandleTurn;
        if (_activeCard.MeCard.NumTargets < _targets.Count)
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
        RoomMB.ActiveRoom.StartCoroutine(WaitAndAttackPlayer());
    }

    private static void AttackPlayer()
    {
        if (BattleManager.BattleManagerRef.Enemies.Count != 0)
        {
            List<Entity> enemies = BattleManager.BattleManagerRef.Enemies;
            int choice = Random.Range(0, enemies.Count);
            Entity attacking = enemies[choice];
            int _attackDamage = attacking.AttackDamage;
            Player P = Player.PlayerRef;
            P.TakeHitDamage(_attackDamage);
            State = BattleActionState.SelectCard;
        }
    }

    private static IEnumerator WaitAndAttackPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        AttackPlayer();
    }
}
