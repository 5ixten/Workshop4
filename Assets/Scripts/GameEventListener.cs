using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvent;
    [SerializeField] private UnityEvent _triggeredEvent;

    void OnEnable()
    {
        _gameEvent.AddListener(this);
    }

    void OnDisable()
    {
        _gameEvent.RemoveListener(this);
    }

    public void EventTriggered()
    {
        _triggeredEvent.Invoke();
    }
}