using System.Collections.Generic;

namespace Tools
{
    public static class EventBus
    {
        private static readonly Dictionary<string, List<EventCallback>> EventDictionary = new Dictionary<string, List<EventCallback>>();
        
        public static void Subscribe(string eventName, EventCallback callback)
        {
            if (EventDictionary.TryGetValue(eventName, out var callbacks))
            {
                callbacks.Add(callback);
            }
            else
            {
                EventDictionary[eventName] = new List<EventCallback>{ callback };
            }
        }

        public static void Unsubscribe(string eventName, EventCallback callback)
        {
            if (EventDictionary.TryGetValue(eventName, out var callbacks))
            {
                callbacks.Remove(callback);
            }
        }

        public static void Trigger(string eventName)
        {
            if (!EventDictionary.TryGetValue(eventName, out var callbacks)) return;

            for (var i = 0; i < callbacks.Count; i++)
            {
                var callback = callbacks[i];
                callback.Invoke();
            }
        }
    }

    public delegate void EventCallback();
    
}