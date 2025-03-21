using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<Type, List<Delegate>> eventListeners = new Dictionary<Type, List<Delegate>>();

    public static void Subscribe<T>(Action<T> listener) where T : class
    {
        Type eventType = typeof(T);
        if (!eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType] = new List<Delegate>();
        }
        eventListeners[eventType].Add(listener);
    }

    public static void Unsubscribe<T>(Action<T> listener) where T : class
    {
        Type eventType = typeof(T);
        if (eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType].Remove(listener);
        }
    }

    public static void UnsubscribeAll()
    {
        eventListeners.Clear();
    }

    public static void Publish<T>(T publishedEvent) where T : class
    {
        Type eventType = typeof(T);
        if (eventListeners.ContainsKey(eventType))
        {
            foreach (var listener in eventListeners[eventType])
            {
                (listener as Action<T>)?.Invoke(publishedEvent);
            }
        }
    }
}
