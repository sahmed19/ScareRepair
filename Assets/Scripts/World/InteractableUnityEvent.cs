using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableUnityEvent : MonoBehaviour, Interactable
{
    public UnityEvent unityEvent;

    public string prompt;
    public float time;
    public bool disableAfterOneInteraction;

    bool interactableEnabled = true;

    public void Interact()
    {
        unityEvent.Invoke();
        if(disableAfterOneInteraction)
        {
            interactableEnabled = false;
        }
    }

    public string Prompt()
    {
        return prompt;
    }

    public float TimeToComplete()
    {
        return time;
    }

    public bool Enabled()
    {
        return interactableEnabled;
    }
}
