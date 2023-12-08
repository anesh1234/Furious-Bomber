using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
//public class CustomGameEvent : UnityEvent<Component, object> { }
public class CustomGameEvent : UnityEvent<object> { }

public class GameEventListener : MonoBehaviour
{

    [Tooltip("Event to register with.")]
    public GameEvent gameEvent;

    [Tooltip("Response to invoke when Event with GameData is raised.")]
    public CustomGameEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(object data)
    {
        response.Invoke(data);
    }
}