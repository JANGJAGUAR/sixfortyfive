using RevelationScripts;
using UnityEngine;
using UnityEngine.UI;

namespace CardScripts
{
    public class CardScript: MonoBehaviour
    {
        public CardSo cardSo;

        public void UseCard()
        {
            CardEventBus.Publish(CardEventType.UseCard, cardSo.type, cardSo.number, cardSo.operation, cardSo.logic);
        }
    }
}