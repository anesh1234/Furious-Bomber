using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
public class GameEvent : ScriptableObject
{

    public List<GameEventListener> listeners = new List<GameEventListener>();

    // Raise event through different method signatures
    // ############################################################

    public void Raise()
    {
        Raise(null, null);
        Debug.Log("Raise(null, null)");
    }

    public void Raise(object data)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(data);
        }                                              /////////////////
        Debug.Log("Entered correct");
    }

    public void Raise(Component sender)
    {
        Raise(sender, null);
        Debug.Log("Raise(sender, null)");
    }

    public void Raise(Component sender, object data)                        /////////////////////////
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(data);
        }
        Debug.Log("for (int i = listeners.Count - 1; i >= 0; i--)listeners[i].OnEventRaised(data);");
    }

    // Manage Listeners
    // ############################################################

    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }

}