using System.Collections.Generic;
using CardScripts;
using UnityEngine.Events;

namespace RevelationScripts
{
    public static class RevelationEventBus
    {
        private static readonly IDictionary<RevelationEventType, UnityEvent<int, string, string>> RevelationEvents =
            new Dictionary<RevelationEventType, UnityEvent<int, string, string>>();
        
        public static void Subscribe(RevelationEventType eventType, UnityAction<int, string, string> listener)
        {
            UnityEvent<int, string, string> thisEvent;

            if (RevelationEvents.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent<int, string, string>();
                thisEvent.AddListener(listener);
                RevelationEvents.Add(eventType, thisEvent);
            }
        }

        public static void Publish(RevelationEventType eventType, int numericPart, string opPart, string logicalPart)
        {
            UnityEvent<int, string, string> thisEvent;

            if (RevelationEvents.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.Invoke(numericPart, opPart, logicalPart);
            }
        }
    }
}