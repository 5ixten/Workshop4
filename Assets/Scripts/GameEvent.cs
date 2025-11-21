using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SO/GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners =
        new List<GameEventListener>();

    public void TriggerEvent()
    {
        foreach (GameEventListener listener in _listeners)
        {
            listener.EventTriggered();
        }
    }

    public void AddListener(GameEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }
}