using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class AddCardToDeckAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.AddCardToDeck;
        // The card you will add
        public override void DoAction(CardActionParameters actionParameters)
        {
            if (CollectionManager != null && GameManager != null) {

                for (int i = 0; i < actionParameters.Value; i++) 
                {
                    Debug.Log(actionParameters.CardTargetCard.CardName);
                    CollectionManager.AddToDeck(actionParameters.CardTargetCard);
                }
            }


            if (FxManager != null)
                FxManager.PlayFx(actionParameters.SelfCharacter.transform, FxType.Buff);

            if (AudioManager != null) 
                AudioManager.PlayOneShot(actionParameters.CardData.AudioType);
        }
    }
}