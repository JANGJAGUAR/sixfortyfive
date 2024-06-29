using System.Collections.Generic;
using UnityEngine.Events;

namespace CardScripts
{
    public static class CardEventBus
    {
        public static readonly IDictionary<CardEventType, UnityEvent<CardType, int, Operator, Logic>> CardEvents =
            new Dictionary<CardEventType, UnityEvent<CardType, int, Operator, Logic>>();

        public static void Subscribe(CardEventType eventType, UnityAction<CardType, int, Operator, Logic> listener)
        {
            UnityEvent<CardType, int, Operator, Logic> thisEvent;

            if (CardEvents.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent<CardType, int, Operator, Logic>();
                thisEvent.AddListener(listener);
                CardEvents.Add(eventType, thisEvent);
            }
        }

        public static void Publish(CardEventType eventType, CardType cardType, int number, Operator op, Logic logic)
        {
            UnityEvent<CardType, int, Operator, Logic> thisEvent;
        
            if (CardEvents.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.Invoke(cardType, number, op, logic);
            }
        }
    }
}