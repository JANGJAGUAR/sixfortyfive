using System.Collections;
using RevelationScripts;
using UnityEngine;
using UnityEngine.UI;

namespace CardScripts
{
    public class CardScript: MonoBehaviour
    {
        public CardSo cardSo;
        private CardDrawer _cardDrawer;

        public void Initialize(CardDrawer drawer)
        {
            _cardDrawer = drawer;
        }
        public void UseCard()
        {
            _cardDrawer.UseHandCard(this);
            CardEventBus.Publish(CardEventType.UseCard, cardSo.type, cardSo.number, cardSo.operation, cardSo.logic);
        }
    }
}