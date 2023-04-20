using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class FatigueAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.Fatigue;
        public override void DoAction(CardActionParameters actionParameters)
        {
            var newTarget = actionParameters.TargetCharacter
            ? actionParameters.TargetCharacter
            : actionParameters.SelfCharacter;
            
            if (!newTarget) return;

            if (CombatManager != null)
                // CombatManager.SetManaTo(0);
                newTarget.CharacterStats.ApplyStatus(StatusType.Fatigue,Mathf.RoundToInt(actionParameters.Value));

            else
                Debug.LogError("There is no CombatManager");

            if (FxManager != null)
                FxManager.PlayFx(actionParameters.SelfCharacter.transform, FxType.Buff);
            
            if (AudioManager != null) 
                AudioManager.PlayOneShot(actionParameters.CardData.AudioType);
        }
    }
}